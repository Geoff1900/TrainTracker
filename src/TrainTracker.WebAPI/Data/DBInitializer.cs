using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainTracker.Core.Entities;

namespace TrainTracker.WebAPI.Data
{
    public static class DBInitializer
    {

        public static void SeedData(TrainTrackerContext context)
        {
            context.Database.EnsureCreated();
            if (context.Persons.Any()) return;

            Person[] persons = new Person[] { new Person { FirstName = "Geoff", LastName = "Norton" } };
            context.Persons.AddRangeAsync(persons);
            context.SaveChanges();

            Course[] courses = new Course[] { new Course {CourseID=1, Name = "ASP.NET Core" }, new Course {CourseID=2, Name = "Pytrhon" } };

            context.Courses.AddRange(courses);
            context.SaveChanges();

            Enrollment[] enrollments = new Enrollment[] { new Enrollment {CourseID = courses[0].CourseID, PersonID = persons[0].Id }, new Enrollment { CourseID = courses[1].CourseID, PersonID = persons[0].Id } };

            context.Enrollments.AddRange(enrollments);
            context.SaveChanges();
            

        }
    }
}
