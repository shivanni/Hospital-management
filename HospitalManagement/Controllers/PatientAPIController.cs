using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HospitalManagement.DAL;
using HospitalManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientAPIController : ControllerBase
    {
        public PatientAPIController()
        {

        }
        [HttpGet]
        public List<PatientModel> Get(string patientName)
        {
            PatientDAL dal = new PatientDAL();
            List<PatientModel> search = (from temp in dal.PatientModels where temp.name == patientName select temp)
                                     .ToList<PatientModel>();
            return search;
        }
        //POST
        [HttpPost]
        public IActionResult Post(PatientModel obj)
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

    }
}
