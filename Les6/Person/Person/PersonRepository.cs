using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigherLowerGame
{
    public class PersonRepository
    {
        #region Fields

        private PersonDbContext _context = new PersonDbContext();

        #endregion Fields

        #region Public Constructors

        public PersonRepository()
        {
        }

        #endregion Public Constructors

        #region Public Methods

        public List<Person> GetAllPersons()
        {
            return _context.Persons.ToList();
        }

        public void AddPerson(Person person)
        {
            _context.Persons.Add(person);
            _context.SaveChanges();
        }

        #endregion Public Methods
    }
}