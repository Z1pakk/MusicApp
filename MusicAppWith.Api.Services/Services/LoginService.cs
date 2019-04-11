using MusicAppWith.Api.Services.Helpers;
using MusicAppWith.Api.Services.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MusicAppWith.Api.Services.Services
{
    public class LoginService
    {
        string _clientId;
        string _startAddress;
        string _clientSecret;

        public LoginService()
        {
            _clientId = GetConfigHelper.GetConfig("ClientId");
            _clientSecret = GetConfigHelper.GetConfig("ClientSecret");
            _startAddress = @"https://api.jamendo.com/v3.0/";
        }
        public string Login(string code,string redirectUrl)
        {
            string address= $@"{_startAddress}oauth/grant";
            using (WebClient client = new WebClient())
            {
                var reqParams = new NameValueCollection();
                reqParams.Add("client_id", _clientId);
                reqParams.Add("client_secret", _clientSecret);
                reqParams.Add("grant_type", "authorization_code");
                reqParams.Add("code", code);
                reqParams.Add("redirect_uri", redirectUrl);
                byte[] responsebytes =  client.UploadValues(new Uri(address), "POST", reqParams);
                string responsebody = Encoding.UTF8.GetString(responsebytes);
                AccessLogin result = JsonConvert.DeserializeObject<AccessLogin>(responsebody);
                return result.access_token;
            }
          
        }
    }
}
