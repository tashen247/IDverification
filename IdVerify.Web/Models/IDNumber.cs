using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdVerify.Web.Models
{
    public class IDNumber
    {
        [Required]
        [MaxLength(13)]
      public string IDnumber { get; set; }
      public string result { get; set; }
    }
}