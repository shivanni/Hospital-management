using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using HospitalManagement.DAL;
using HospitalManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace HospitalManagement.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    [EnableCors("MyAllowSpecificOrigins")]

    public class PatientAPIController : ControllerBase
    {
        public string ConStr { get; private set; }


        [HttpGet]
        public IActionResult Get(string patientName)
        {
            PatientDAL dal = new PatientDAL(ConStr);
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
        public string Post([FromBody] PatientModel obj)
        {

            var context = new ValidationContext(obj, null, null);
            //fill the errors

            var result = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, context, result, true);

            if (result.Count == 0)
            {
                PatientDAL dal = new PatientDAL(ConStr);
                dal.Database.EnsureCreated();   // ensure table is created or not
                dal.Add(obj);                   //inmemory
                dal.SaveChanges();              // pysical commit save to database         


                List<PatientModel> recs = dal.PatientModels.Include(pat => pat.problems).
                ToList<PatientModel>();
                //List<DiseaseModel> dic = dal.Diseas.ToList<DiseaseModel>();
                //dynamic dics = new ExpandoObject();
                //dics.PatientModel = recs;
                //dics.DiseaseModel = dic;


                var json = JsonConvert.SerializeObject(recs, Formatting.None,
                                         new JsonSerializerSettings()
                                         {
                                             ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                                         });
                return json;

               // return StatusCode(200, recs);
            }
            else
            {
                var json = JsonConvert.SerializeObject(result, Formatting.None,
                                         new JsonSerializerSettings()
                                         {
                                             ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                                         });
                // return StatusCode(500, result);
                return json;
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