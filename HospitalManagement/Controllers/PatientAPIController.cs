using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HospitalManagement.DAL;
using HospitalManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class PatientAPIController : ControllerBase
    {

        [EnableCors("MyAllowSpecificOrigins")]
        [HttpGet]
        public IActionResult Get(string patientName)
        {
            PatientDAL dal = new PatientDAL();
            List<PatientModel> search = (from temp in dal.PatientModels
                                         where temp.name == patientName
                                         select temp)
                                         .ToList<PatientModel>();
            return Ok(search);
        }

        // GET
        [HttpGet("{id}", Name = "GetPatient")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/PatientAPI
        [HttpPost]
        public IActionResult Post([FromBody] PatientModel obj)
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
            else
            {
                return StatusCode(500, result); 
            }
        }

        // PUT: 
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: 
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}