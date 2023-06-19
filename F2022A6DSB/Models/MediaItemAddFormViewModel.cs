using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace F2022A6DSB.Models
{
    public class MediaItemAddFormViewModel
    {
        public int ArtistId { get; set; }

        public string ArtistInfo { get; set; }

        [Required, StringLength(100)]
        [Display(Name = "Description")]
        public string Caption { get; set; }

        [Required]
        [Display(Name = "Media Item")]
        [DataType(DataType.Upload)]
        public string MediaItemUpload { get; set; }
    }
}