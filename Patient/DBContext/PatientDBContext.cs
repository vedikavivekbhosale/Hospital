using DBContext.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DBContext
{
    public class PatientDBContext : DbContext
    {
        public PatientDBContext() { }
        public PatientDBContext(DbContextOptions<PatientDBContext> options) : base(options) => Database.EnsureCreated();

        public virtual DbSet<PatientDetails> PatientDetails { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=PatientDB;User ID=myusername;Password=mypassword;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("dblink");
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(Accesory).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}

