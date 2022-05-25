using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ProjectSource.Models
{
    public class Doctor
    {

        public int Doctorid { get; set; }

        [Required(ErrorMessage = "Enter First Name")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "special characters not allowed")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Enter Last Name")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "special characters not allowed")]
        public string Lastname { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Specialization { get; set; }
        [Required]
        public string Visitinghours { get; set; }
        [Required]
        public string Timings { get; set; }
    }
}
