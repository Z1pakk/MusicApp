using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicAppWithApi.Models
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
        public DateTime ReleaseDate { get; set; }
        [Required]
        public string ArtistName { get; set; }

        public string Image { get; set; }

    }
}