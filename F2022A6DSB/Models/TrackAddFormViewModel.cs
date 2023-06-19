using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace F2022A6DSB.Models
{
    public class TrackAddFormViewModel
    {
        [StringLength(100)]
        public string AlbumName { get; set; }

        [Display(Name = "Track name")]
        [Required, StringLength(200)]
        public string Name { get; set; }

        // Simple comma-separated string of all the track's composers
        [Display(Name = "Composer names (comma-separated)")]
        [Required, StringLength(500)]
        public string Composers { get; set; }

        [Display(Name = "Track genre")]
        [Required]
        public SelectList GenreList { get; set; }

        [Required]
        [Display(Name = "Sample clip")]
        [DataType(DataType.Upload)]
        public string AudioUpload { get; set; }

    }
}