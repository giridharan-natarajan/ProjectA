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
        
        public IActionResult Homepage()
        {
            return View();
        }
        [Route("Home/Insertdo")]
        public IActionResult Insertdo()
        {
            return View();
        }
        public IActionResult DoctorAd(Doctor doc)
        {
            ClinicDAL mobj = new ClinicDAL();
            int result = mobj.Doctord(doc);
            if (result == 1)
                return Content("Doctor added succesfully");
            else
            return View("Insertdo");
        }
        [Route("Home/Insertpat")]
        public IActionResult Insertpat()
        {
            return View();
        }
        public IActionResult Patientad(Patient pat)
        {
            ClinicDAL cobj = new ClinicDAL();
            int result = cobj.Patientp(pat);
            if (result == 1)
                return Content("Patient added succesfully");
            else
                return View("Insertpat");
            
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
}
