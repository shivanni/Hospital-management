using HospitalManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.DAL
{
    public class PatientDAL : DbContext
    {

        string conconStr = "";

        public PatientDAL(string ConStr)
        {
            this.conconStr = ConStr;
        }

        public PatientDAL(DbContextOptions<PatientDAL> options) : base(options)
        {

        }

        public PatientDAL()
        {
        }
        
             protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(conconStr);
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-073HNCL;Initial Catalog=Management;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientModel>()
               .ToTable("tb1Patients");

            modelBuilder.Entity<Problem>()
                .ToTable("tb1Problems");

            modelBuilder.Entity<DiseaseModel>()
             .ToTable("tb1CDisease");

            modelBuilder.Entity<PatientModel>()
                .HasKey(p => p.id);
    
            modelBuilder.Entity<Problem>()
               .HasKey(p => p.id);


            modelBuilder.Entity<DiseaseModel>()
                .HasKey(p => p.id);
            // one to many
            modelBuilder.Entity<PatientModel>()
                .HasMany(c => c.problems)
                .WithOne(e => e.patient);
            modelBuilder.Entity<PatientModel>();

        }

        public DbSet<PatientModel> PatientModels { get; set; }
        public DbSet<Problem> Problems { get; set; }
    
        public DbSet<DiseaseModel> Diseas { get; set; }

    }
}

