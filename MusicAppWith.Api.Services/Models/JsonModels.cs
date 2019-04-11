using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicAppWith.Api.Services.Models
{
    public class JsonModel
    {
        [JsonProperty("headers")]
        public JsonHeader header { get; set; }
        [JsonProperty("results")]
        public List<MusicModel> results { get; set; }
    }

    public class JsonHeader
    {
        [JsonProperty("results_fullcount")]
        public int results_fullcount { get; set; }
    }

    public class MusicModel
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("artist_name")]
        public string artist_name { get; set; }
        [JsonProperty("album_name")]
        public string album_name { get; set; }
        [JsonProperty("releasedate")]
        public DateTime releasedate { get; set; }
        [JsonProperty("audiodownload")]
        public string audiodownload { get; set; }
        [JsonProperty("shorturl")]
        public string shorturl { get; set; }
        [JsonProperty("image")]
        public string image { get; set; }
        [JsonProperty("stats")]
        public StatsModel stats { get; set; }
    }
    public class StatsModel
    {
        [JsonProperty("rate_downloads_total")]
        public int rate_downloads_total { get; set; }
        [JsonProperty("likes")]
        public int likes { get; set; }
        [JsonProperty("dislikes")]
        public int dislikes { get; set; }
    }
    public class AccessLogin
    {
        [JsonProperty("access_token")]
        public string access_token { get; set; }
    }
}
