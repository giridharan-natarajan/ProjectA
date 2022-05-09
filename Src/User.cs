using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ProjectSource.Models
{
    public class User
    {
        [Required(ErrorMessage = "Username*")]
        [RegularExpression("[A-Z]{4}-[0-9]{2}")]
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        [Required(ErrorMessage = "Password*")]
        [RegularExpression("[0-9]{5}")]
        public string Paasword { get; set; }
    }
}
