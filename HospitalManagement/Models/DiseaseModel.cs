using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Models
{
    public class DiseaseModel
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
       // public PatientModel patient { get; set; }   //Imverse Navigation Property
    }
}