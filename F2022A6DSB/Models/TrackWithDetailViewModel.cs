using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace F2022A6DSB.Models
{
    public class TrackWithDetailViewModel : TrackBaseViewModel
    {

        [StringLength(200)]
        public string AudioContentType { get; set; }

        public byte[] Audio { get; set; }

    }
}