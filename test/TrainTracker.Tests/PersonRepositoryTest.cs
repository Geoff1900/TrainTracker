using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrainTracker.Core.Entities;
using TrainTracker.WebAPI.Data;
using Xunit;

namespace TrainTracker.Tests
{
    public class PersonRepositoryTest
    {
        [Fact]
        public void Get_RepoHasThreePeople_ReturnsThreePeople()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<TrainTrackerContext>().UseInMemoryDatabase($"PersonRepositoryDatabase{ Guid.NewGuid()}").Options;

            using (var ctx = new TrainTrackerContext(options))
            {
                Person[] persons = new Person[] {new Person() { FirstName = "Geoff", LastName = "Norton" },
                           new Person(){FirstName = "Sandra", LastName = "Norton" },
                           new Person(){FirstName = "Alice", LastName = "Norton" } };

                ctx.Persons.AddRange(persons);
                ctx.SaveChanges();
                var personRepo = new PersonRepository(ctx);
            }

            //Act
            using (var ctx = new TrainTrackerContext(options))
            {
                var personRepo = new PersonRepository(ctx);
                var results = personRepo.GetAll();
                var actual = results.Count();
                //Assert
                Assert.Equal(3, actual);
            }
        }

        [Fact]

        public void Add_LastNameIsMissing_ArgumentExceptionThrown()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<TrainTrackerContext>().UseInMemoryDatabase($"PersonRepositoryDatabase{Guid.NewGuid()}").Options;
            using (var ctx = new TrainTrackerContext(options))
            {
                var personRepo = new PersonRepository(ctx);
                //Assert
                Assert.Throws<ArgumentNullException>(()=>personRepo.Create(new Person(){ FirstName = "Geoff"}));
            }
        }
    }
}
