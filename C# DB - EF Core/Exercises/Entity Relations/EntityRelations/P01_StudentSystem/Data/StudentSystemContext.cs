﻿namespace P01_StudentSystem.Data
{
    using System;
    using JetBrains.Annotations;
    using Microsoft.EntityFrameworkCore;
    using P01_StudentSystem.Data.Models;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {

        }

        public StudentSystemContext(DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Homework> HomeworkSubmissions { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.OnConfiguringStudent(modelBuilder);
            this.OnConfiguringCourse(modelBuilder);
            this.OnConfiguringResource(modelBuilder);
            this.OnConfiguringHomework(modelBuilder);
            this.OnConfiguringStudentCourse(modelBuilder);
        }

        private void OnConfiguringStudentCourse(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.CourseId });

                entity
                .HasOne(e => e.Student)
                .WithMany(s => s.CourseEnrollments)
                .HasForeignKey(e => e.StudentId);

                entity
                .HasOne(e => e.Course)
                .WithMany(c => c.StudentsEnrolled)
                .HasForeignKey(e => e.CourseId);
            });
        }

        private void OnConfiguringHomework(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Homework>(entity =>
            {
                entity.HasKey(e => e.HomeworkId);

                entity.Property(e => e.Content)
                .IsRequired();

                entity
                .HasOne(e => e.Student)
                .WithMany(s => s.HomeworkSubmissions);

                entity
                .HasOne(e => e.Course)
                .WithMany(c => c.HomeworkSubmissions);
            });
        }

        private void OnConfiguringResource(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasKey(e => e.ResourceId);

                entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

                entity.Property(e => e.Url)
                .IsRequired();

                entity
                .HasOne(e => e.Course)
                .WithMany(c => c.Resources);
            });
        }

        private void OnConfiguringCourse(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.CourseId);

                entity.Property(e => e.Name)
                .HasMaxLength(80)
                .IsUnicode()
                .IsRequired();

                entity.Property(e => e.Description)
                .IsUnicode();
            });
        }

        private void OnConfiguringStudent(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode()
                .IsRequired();

                entity.Property(e => e.PhoneNumber)
                .HasColumnType("CHAR(10)");
            });
            
        }
    }
}
