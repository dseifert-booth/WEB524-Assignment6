using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace F2022A6DSB.Models
{
    public class AlbumAddViewModel
    {

        [Display(Name = "Album Name")]
        [Required, StringLength(100)]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime ReleaseDate { get; set; }

        // Get from Apple iTunes Preview, Amazon, or Wikipedia
        [Display(Name = "Album cover art")]
        [Required, StringLength(512)]
        public string UrlAlbum { get; set; }

        [Display(Name = "Album's primary genre")]
        [Required]
        public string Genre { get; set; }

        [StringLength(10000)]
        public string Background { get; set; }

    }
}