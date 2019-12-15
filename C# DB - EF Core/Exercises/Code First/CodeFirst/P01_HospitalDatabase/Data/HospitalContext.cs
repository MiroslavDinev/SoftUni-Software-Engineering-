using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_HospitalDatabase.Data
{
    public class HospitalContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Diagnose> Diagnoses { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Visitation> Visitations { get; set; }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<PatientMedicament> PatientsMedicaments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.ConfigurePatientEntity(modelBuilder);
            this.ConfigureVisitationEntity(modelBuilder);
            this.ConfigureDiagnoseEntity(modelBuilder);
            this.ConfigureMedicamentEntity(modelBuilder);
            this.ConfigurePatientMedicamentEntity(modelBuilder);
            this.ConfigureDoctorEntity(modelBuilder);
        }

        private void ConfigureDoctorEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>()
                .HasKey(d => d.DoctorId);

            modelBuilder.Entity<Doctor>()
                .Property(n => n.Name)
                .HasMaxLength(100)
                .IsUnicode();

            modelBuilder.Entity<Doctor>()
                .Property(s => s.Specialty)
                .HasMaxLength(100)
                .IsUnicode();

            modelBuilder.Entity<Doctor>()
                .HasMany(v => v.Visitations)
                .WithOne(d => d.Doctor);
        }

        private void ConfigurePatientMedicamentEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientMedicament>()
                .HasKey(x => new { x.PatientId, x.MedicamentId });

            modelBuilder.Entity<PatientMedicament>()
                .HasOne(p => p.Patient)
                .WithMany(ps => ps.Prescriptions)
                .HasForeignKey(p => p.PatientId);

            modelBuilder.Entity<PatientMedicament>()
                .HasOne(m => m.Medicament)
                .WithMany(p => p.Prescriptions)
                .HasForeignKey(m => m.MedicamentId);
        }

        private void ConfigureMedicamentEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medicament>()
                .HasKey(m => m.MedicamentId);

            modelBuilder.Entity<Medicament>()
                .Property(n => n.Name)
                .HasMaxLength(50)
                .IsUnicode();
        }

        private void ConfigureDiagnoseEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diagnose>()
                .HasKey(d => d.DiagnoseId);

            modelBuilder.Entity<Diagnose>()
                .Property(n => n.Name)
                .HasMaxLength(50)
                .IsUnicode();

            modelBuilder.Entity<Diagnose>()
                .Property(c => c.Comments)
                .HasMaxLength(250)
                .IsUnicode();
        }

        private void ConfigureVisitationEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Visitation>()
                .HasKey(v => v.VisitationId);

            modelBuilder.Entity<Visitation>()
                .Property(c => c.Comments)
                .HasMaxLength(250)
                .IsUnicode();
                
        }

        private void ConfigurePatientEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .HasKey(p => p.PatientId);

            modelBuilder.Entity<Patient>()
                .Property(f => f.FirstName)
                .HasMaxLength(50)
                .IsUnicode();

            modelBuilder.Entity<Patient>()
                .Property(l => l.LastName)
                .HasMaxLength(50)
                .IsUnicode();

            modelBuilder.Entity<Patient>()
                .Property(a => a.Address)
                .HasMaxLength(250)
                .IsUnicode();

            modelBuilder.Entity<Patient>()
                .Property(e => e.Email)
                .HasMaxLength(80)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .HasMany(v => v.Visitations)
                .WithOne(p => p.Patient);

            modelBuilder.Entity<Patient>()
                .HasMany(d => d.Diagnoses)
                .WithOne(p => p.Patient);
           
        }
    }
}
