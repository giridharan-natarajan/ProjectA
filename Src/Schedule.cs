using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSource.Models
{
    public class Schedule
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public string Specializations { get; set; }
        public string DoctorName { get; set; }
        public string VisitDate { get; set; }
       
        public string AppointmentTime { get; set; }

    }
}
