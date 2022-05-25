using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectSource.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ProjectSource.DAL;
namespace ProjectSource.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Route("Home/Validate")]
        public IActionResult Validate(User us) //validating user
        {
            if (ModelState.IsValid)
            {
                ClinicDAL chkobj = new ClinicDAL();
                int result = chkobj.CheckUse(us);
                if (result==1)
                {
                    return View("Homepage");
                }
                else
                {
                    TempData["msg"] = "<script>alert('Incorrect Username or Password');</script>";
                    return View("Index");
                }
                
            }
            else
            {
                return View("Index");
            }
        }
       
        public IActionResult Homepage()//homepageview

        {
            
            return View();
        }
        [Route("Home/Insertdo")]
        public IActionResult Insertdo()
        {
            return View();
        }
        public IActionResult DoctorAd(Doctor doc)//adding doctor
        {
            if (ModelState.IsValid)
            {
                ClinicDAL mobj = new ClinicDAL();
                int result = mobj.Doctord(doc);
                if (result == 1)
                {
                    TempData["msg"] = "<script>alert('Doctor added succesfully');</script>";
                    return View("Insertdo");
                }
                else
                    return View("Homepage");
            }
            else
            {
                return View("Insertdo");
            }
            }
        
        public IActionResult DoctorDetails()//doctor details
        {
            ClinicDAL cliDAL = new ClinicDAL();
            List<Doctor> DoctorList = new List<Doctor>();
            DoctorList = cliDAL.Viewdoctor();
            return View(DoctorList);
        }
        public IActionResult DeleteDoctor(int id)//delete appointment check here
        {
            ClinicDAL cobj = new ClinicDAL();
            int result = cobj.DeleteDoc(id);
            if (result == 1)
            {

                return View("InsSchedule");
            }
            else
            {
                return View("Homepage");
            }
        }
                [Route("Home/Insertpat")]
        public IActionResult Insertpat()
        {
            return View();
        }

        public IActionResult Patientad(Patient pat)//patient insert
        {
            if (ModelState.IsValid)
            {

                ClinicDAL cobj = new ClinicDAL();
            int result = cobj.Patientp(pat);
                if (result == 1)
                {
                    TempData["msg"] = "<script>alert('Patient added succesfully');</script>";
                    return View("Insertpat");
                }
                else
                    return View("Homepage");
            }
            else
            {
                return View("Insertpat");
            } 
                
        
           

        }
        [Route("Home/InsSchedule")]
        public IActionResult InsSchedule()
        {
            return View();
        }

        public IActionResult ScheduleAd(Schedule sc)//inserting schedule
        {
            ClinicDAL cobj = new ClinicDAL();
            int result =cobj.Schedulec(sc);
            if (result == 1)
            {
                TempData["msg"] = "<script>alert('Appointment added succesfully');</script>";
                return View("InsSchedule");
            }
            else
                return View("Homepage");
        }
        
        public IActionResult Showappointmentt()//view/show appointment
            {
                ClinicDAL cliDAL = new ClinicDAL();
                List<Schedule> ScheduleList = new List<Schedule>();
                ScheduleList = cliDAL.Viewappointment();
                return View(ScheduleList);
            }
        public IActionResult Deleteda(int id)//delete appointment check here
        {
            ClinicDAL cobj = new ClinicDAL();
            int result = cobj.Deletedat(id);
            if (result == 1)
            {
               
                return View("Homepage");
            }
            else
                
            return View("Homepage");
        }
    }


        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }

