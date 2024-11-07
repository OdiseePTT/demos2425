using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public class PersonRepository
    {
        #region Fields

        private PersonDbContext _context;

        #endregion Fields

        #region Public Constructors

        public PersonRepository():this(new PersonDbContext())
        {
        }

        public PersonRepository(PersonDbContext personDbContext)
        {
            _context = personDbContext;
        }

        #endregion Public Constructors

        #region Public Methods

        public List<Person> GetAllPersons()
        {
            return _context.Persons.ToList();
        }

        public List<Person> GetAllPersonsWitName(string name)
        {
            return _context.Persons.Where(p => p.FirstName == name).OrderBy(p => p.BirthDate).ToList();
        }

        public void AddPerson(Person person)
        {
            _context.Persons.Add(person);
            _context.SaveChanges();
        }

        #endregion Public Methods
    }
}