using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace F2022A6DSB.Models
{
    public class ArtistWithDetailViewModel : ArtistBaseViewModel
    {

        [Display(Name = "Number of Albums")]
        public int NumAlbums { get; set; }

    }
}