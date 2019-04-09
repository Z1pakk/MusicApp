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
        public MusicGeneralViewModel GetMusics(int page,int count)
        {
            page = page == 1 ? 0 : page;
            string clientId = GetConfigHelper.GetConfig("ClientId");
            string address = $@"https://api.jamendo.com/v3.0/tracks/?client_id={clientId}&format=jsonpretty&limit=12&include=musicinfo+stats&order=downloads_total_desc&fullcount=true&offset={page*count}";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(address);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            string response = string.Empty;
            using (HttpWebResponse httpresponse = (HttpWebResponse)request.GetResponse())
            using (Stream stream = httpresponse.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                response = reader.ReadToEnd();
            }
            JsonModel models = JsonConvert.DeserializeObject<JsonModel>(response);
            var musics =
               Mapper.Map<List<MusicModel>, List<MusicViewModel>>(models.results);

            MusicGeneralViewModel model = new MusicGeneralViewModel()
            {
                Musics = musics,
                OtherInfo = Mapper.Map<JsonHeader, OtherInfo>(models.header)
            };
            return model;
        }
    }
}
