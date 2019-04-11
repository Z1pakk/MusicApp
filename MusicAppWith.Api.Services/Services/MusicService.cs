using AutoMapper;
using MusicAppWith.Api.Services.Helpers;
using MusicAppWith.Api.Services.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MusicAppWith.Api.Services.Services
{
    public class MusicService
    {
        string _clientId;
        string _startAddress;
        public MusicService()
        {
            _clientId = GetConfigHelper.GetConfig("ClientId");
            _startAddress = @"https://api.jamendo.com/v3.0/";
        }
        private string GetLink(int offset,string text)
        {
            return $@"{_startAddress}tracks/?client_id={_clientId}&format=jsonpretty&limit=12&include=musicinfo+stats&order=downloads_total_desc&fullcount=true&search={text}&offset={offset}";
        }
        public MusicGeneralViewModel GetMusics(int page, int count,string searchText)
        {
            page = page == 1 ? 0 : page;
            string address = GetLink(page * count, searchText);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(address);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            string response = string.Empty;
            MusicGeneralViewModel model = new MusicGeneralViewModel();
            try
            {
                using (HttpWebResponse httpresponse = (HttpWebResponse)request.GetResponse())
                {

                    if (httpresponse.StatusCode == HttpStatusCode.OK)
                    {
                        using (Stream stream = httpresponse.GetResponseStream())
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            response = reader.ReadToEnd();
                        }
                        JsonModel models = JsonConvert.DeserializeObject<JsonModel>(response);
                        var musics =
                           Mapper.Map<List<MusicModel>, List<MusicViewModel>>(models.results);

                        model = new MusicGeneralViewModel()
                        {
                            Musics = musics,
                            OtherInfo = Mapper.Map<JsonHeader, OtherInfo>(models.header)
                        };
                    }
                    else
                    {
                        model.Error = "Error when connected to API";
                    }
                }
            }
            catch (WebException ex)
            {
                model.Error = ex.Message;
            }
            return model;
        }

    }
}
