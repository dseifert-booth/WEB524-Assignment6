using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace F2022A6DSB.Models
{
    public class ArtistAddViewModel
    {

        [Display(Name = "Artist name or stage name")]
        [Required, StringLength(100)]
        public string Name { get; set; }

        // For an individual, a birth name
        [Display(Name = "If applicable, artist's birth name")]
        [StringLength(100)]
        public string BirthName { get; set; }

        // For an individual, a birth date
        // For all others, can be the date the artist started working together
        [Display(Name = "Birth date, or start date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime BirthOrStartDate { get; set; }

        // Get from Apple iTunes Preview, Amazon, or Wikipedia
        [Display(Name = "URL to artist photo")]
        [Required, StringLength(512)]
        public string UrlArtist { get; set; }

        [Display(Name = "Artist's primary genre")]
        [Required]
        public string Genre { get; set; }

        [Display(Name = "Artist portrayal")]
        [DataType(DataType.MultilineText)]
        [StringLength(10000)]
        public string Portrayal { get; set; }

    }
}