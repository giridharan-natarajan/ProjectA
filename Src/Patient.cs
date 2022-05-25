using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ProjectSource.Models
{
    public class Patient
    {

        [Required(ErrorMessage = "Enter First Name")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "special characters not allowed")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Enter Last Name")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "special characters not allowed")]
        public string Lastname { get; set; }
        
        public string Gender { get; set; }
        
        public string Dateofbirth { get; set; }
        [Required]
        [Range(0,120,ErrorMessage ="Enter between 0 and 120" )]
        public int Age { get; set; }
    }
}
