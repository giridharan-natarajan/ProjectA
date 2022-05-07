using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSource.Models
{
    public class Doctor
    {
    
      public int Doctorid { get; set; }
      public string  Firstname { get; set; }
      public  string Lastname { get; set; }
      public string Gender { get; set; }
      public string Specialization { get; set; }
      public  string  Visitinghours { get; set; }
    }
}
