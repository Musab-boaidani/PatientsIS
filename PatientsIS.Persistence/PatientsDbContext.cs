using Microsoft.EntityFrameworkCore;
using PatientsIS.Domain;
using System;

namespace PatientsIS.Persistence
{
    public class PatientsDbContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public PatientsDbContext( DbContextOptions<PatientsDbContext> options) : base(options)
        {
        }

       
    }
}
