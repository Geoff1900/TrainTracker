﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainTracker.Core.Entities;

namespace TrainTracker.WebAPI.Data
{
    public class TrainTrackerContext : DbContext
    {
        public TrainTrackerContext(DbContextOptions<TrainTrackerContext> options) : base(options)
        {
        }
        DbSet<Person> Persons { get; set; }
        DbSet<Course> Courses { get; set; }
        DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Person>().ToTable("Student");
        }
    }
}

