using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace F2022A6DSB.Models
{
    public class AlbumBaseViewModel : AlbumAddViewModel
    {

        [Key]
        public int Id { get; set; }

        [Display(Name = "URL to album image (cover art)")]
        [Required, StringLength(512)]
        public new string UrlAlbum { get; set; }

    }
}