using HospitalManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
               .ToTable("tb1Patient");

            modelBuilder.Entity<Problem>()
                .ToTable("tb1Problem");

            modelBuilder.Entity<PatientModel>()
                .HasKey(p => p.id);
    
            modelBuilder.Entity<Problem>()
               .HasKey(p => p.id);

            // one to many
            modelBuilder.Entity<PatientModel>()
                .HasMany(c => c.problems)
                .WithOne(e => e.patient);
            modelBuilder.Entity<PatientModel>();

        }

        public DbSet<PatientModel> PatientModels { get; set; }
        public DbSet<Problem> Problems { get; set; }


    }
}

