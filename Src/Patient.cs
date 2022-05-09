using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ProjectSource.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        [Required]       
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Dateofbirth { get; set; }
        [Required]
        public int Age { get; set; }
    }
}
