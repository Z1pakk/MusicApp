using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicAppWith.Api.Services.Models
{
    //Обьект который будет возвращаеться в контролер
    public class MusicGeneralViewModel
    {
        public MusicGeneralViewModel()
        {
            Musics = new List<MusicViewModel>();
        }
        public OtherInfo OtherInfo { get; set; }
        public List<MusicViewModel> Musics { get; set; }
        public string Error { get; set; }

    }
}
