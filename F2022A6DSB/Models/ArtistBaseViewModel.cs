using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace F2022A6DSB.Models
{
    public class ArtistBaseViewModel : ArtistAddViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Artist photo")]
        [Required, StringLength(512)]
        public new string UrlArtist { get; set; }

        [Required, StringLength(200)]
        public string Executive { get; set; }
    }
}