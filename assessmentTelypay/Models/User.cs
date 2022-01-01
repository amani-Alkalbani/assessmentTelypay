using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace assessmentTelypay.Models
{
    public class User
    {


        [Key]
        public int ID { get; set; }

        [Required]
     
        public string Name { get; set; }

        [Required(ErrorMessage = "Required!")]
        [StringLength(20, MinimumLength = 3)]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Compare("password")]
        public string confirm { get; set; }
    }
}