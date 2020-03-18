using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainTracker.Core.Entities;
using TrainTracker.Core.Services;

namespace TrainTracker.WebAPI.Data
{
    public class PersonRepository : IDisposable, IPersonService
    {
        private TrainTrackerContext _context;
        public PersonRepository(TrainTrackerContext ctx)
        {
            _context = ctx;
        }

        public IEnumerable<Person> GetAll()
        {
            return _context.Persons.ToList();
        }

        public void Create(Person person)
        {
            if (person.LastName == null) throw new ArgumentNullException("Person must have a last name");
        }
               
        public Person FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id, Person person)
        {
            throw new NotImplementedException();
        }

        public void Update(Person person)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}
