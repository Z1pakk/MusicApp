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
            return ConfigurationManager.AppSettings.Get(name);
        }
    }
}
