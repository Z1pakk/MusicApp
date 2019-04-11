using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicAppWith.Api.Services.Helpers
{
    public static class GetConfigHelper
    {
        public static string GetConfig(string name)
        {
            //Возвращает выбраное значение из App.Config с помощью библиотеки System.Configuration 
            //и обьекта ConfigurationManager
            return ConfigurationManager.AppSettings.Get(name);
        }
    }
}
