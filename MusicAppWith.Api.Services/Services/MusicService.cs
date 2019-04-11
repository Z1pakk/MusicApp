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
            //Берем ид клиента из App.Config
            _clientId = GetConfigHelper.GetConfig("ClientId");
            _startAddress = @"https://api.jamendo.com/v3.0/";
        }
        private string GetLink(int offset,string text)
        {
            //Ссылка формата 
            //https://api.jamendo.com/v3.0/tracks/?client_id=your_client_id&format=jsonpretty&limit=2&fuzzytags=groove+rock&speed=high+veryhigh&include=musicinfo&groupby=artist_id
            return $@"{_startAddress}tracks/?client_id={_clientId}&format=jsonpretty&limit=12&include=musicinfo+stats&order=downloads_total_desc&fullcount=true&search={text}&offset={offset}";
        }
        public MusicGeneralViewModel GetMusics(int page, int count,string searchText)
        {
            //Проверка если страница = 1 тогда ставим на 0 чтобы небыло отступа.
            page = page == 1 ? 0 : page;
            //Возвращает ссылку API, которой мы передаем на какое количество будем отступать и текст по которому искать.
            string address = GetLink(page * count, searchText);
            //Создаем обьект для запроса по адрессу.
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(address);
            //Автоматичне зжимання
            request.AutomaticDecompression = DecompressionMethods.GZip;

            string response = string.Empty;
            MusicGeneralViewModel model = new MusicGeneralViewModel();
            try
            {
                //Берем ответ от запроса в виде JSON
                using (HttpWebResponse httpresponse = (HttpWebResponse)request.GetResponse())
                {
                    //Проверяем ли запрос вернул СтатусКод 200 тоесть OK
                    if (httpresponse.StatusCode == HttpStatusCode.OK)
                    {
                        //Конвертируем поток с данными в string
                        using (Stream stream = httpresponse.GetResponseStream())
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            response = reader.ReadToEnd();
                        }
                        //Конвертируєм текст в обьекты с помощью библиотеки NewtonSoft.Json.
                        JsonModel models = JsonConvert.DeserializeObject<JsonModel>(response);
                        //С помощью библиотеки AutoMapper переводим обьекты с MusciModel в обьект MusicViewModel.
                        var musics =
                           Mapper.Map<List<MusicModel>, List<MusicViewModel>>(models.results);

                        model = new MusicGeneralViewModel()
                        {
                            Musics = musics,
                            //Также переводим другую информацию в красивый обьект.
                            OtherInfo = Mapper.Map<JsonHeader, OtherInfo>(models.header)
                        };
                    }
                    else
                    {
                        //Если ошибка возвращаем error
                        model.Error = "Error when connected to API";
                    }
                }
            }
            catch (WebException ex)
            {
                //Если ошибка возвращаем error
                model.Error = ex.Message;
            }
            //Возвращаем 
            return model;
        }

    }
}
