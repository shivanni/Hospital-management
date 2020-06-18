using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalManagement.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using HospitalManagement.DAL;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Controllers
{
    // [EnableCors("MyAllowSpecificOrigins")]
    public class PatientController : Controller
    {
      
        public IActionResult Submit([FromBody] PatientModel obj)
        {
           
            var context = new ValidationContext(obj, null, null);

            var result = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, context, result, true);

            if (result.Count == 0)
            {
                PatientDAL dal = new PatientDAL();
                dal.Database.EnsureCreated(); 
                dal.Add(obj); 
                dal.SaveChanges();

                List<PatientModel> recs = dal.PatientModels.ToList<PatientModel>();

                return StatusCode(200, recs); 
            }
            else {
                return StatusCode(500, result); 
            }
        }

        public IActionResult Update()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}