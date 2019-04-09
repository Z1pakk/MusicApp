using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicAppWith.Api.Services.Models
{
    public class MusicGeneralViewModel
    {
        public OtherInfo OtherInfo { get; set; }
        public List<MusicViewModel> Musics { get; set; }
        
    }
}
