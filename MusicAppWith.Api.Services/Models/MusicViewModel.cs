using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicAppWith.Api.Services.Models
{
    public class MusicViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string AlbumName { get; set; }
        [Required]
        public string ReleaseDate { get; set; }
        [Required]
        public string ArtistName { get; set; }
        [Required]
        public string DownloadLink { get; set; }
        [Required]
        public string ListenUrl { get; set; }

        public string Image { get; set; }

        public int Downloads { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }

    }

}