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
    public class DiseaseController : ControllerBase
    {
        public string ConStr { get; private set; }
        public DiseaseController()
        {

        }      

        // GET: api/Disease

        [HttpGet]
        public IActionResult Get()
        {
            PatientDAL dal = new PatientDAL(ConStr);
            List<DiseaseModel> recs = dal.Diseas.ToList();
            return StatusCode(200, recs);
        }



        // POST: api/Disease
        [HttpPost]
       
        public IActionResult Post([FromBody] DiseaseModel obj)
        {

            var context = new ValidationContext(obj, null, null);          

            var result = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, context, result, true);

            if (result.Count == 0)
            {
                PatientDAL dal = new PatientDAL(ConStr);
                dal.Database.EnsureCreated();   // ensure table is created or not
                dal.Add(obj);                   //inmemory
                dal.SaveChanges();              // pysical commit save to database       
               List<DiseaseModel> recs = dal.Diseas.ToList();
                return StatusCode(200, recs);
            }
            else
            {
                return StatusCode(500, result);
            }
        }

        //// PUT: api/Disease/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
