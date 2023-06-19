using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace F2022A6DSB.Models
{
    public class TrackBaseViewModel
    {

        [Key]
        public int Id { get; set; }

        [Display(Name = "Track name")]
        [Required, StringLength(200)]
        public string Name { get; set; }

        // Simple comma-separated string of all the track's composers
        [Display(Name = "Composer names (comma-separated)")]
        [Required, StringLength(500)]
        public string Composers { get; set; }

        [Display(Name = "Track genre")]
        [Required]
        public string Genre { get; set; }

        // User name who added/edited the track
        [Required, StringLength(200)]
        public string Clerk { get; set; }

        [Display(Name = "Sample clip")]
        public string AudioUrl
        {
            get
            {
                return $"/audio/{Id}";
            }
        }

    }
}