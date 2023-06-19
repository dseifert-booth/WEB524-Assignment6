using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace F2022A6DSB.Models
{
    public class AlbumAddFormViewModel
    {

        [Display(Name = "Album Name")]
        [Required, StringLength(100)]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        // Get from Apple iTunes Preview, Amazon, or Wikipedia
        [Display(Name = "URL to album image (cover art)")]
        [Required, StringLength(512)]
        public string UrlAlbum { get; set; }

        [Display(Name = "Album's primary genre")]
        [Required]
        public SelectList GenreList { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(10000)]
        public string Background { get; set; }

        [StringLength(120)]
        public string KnownArtist { get; set; }

    }
}