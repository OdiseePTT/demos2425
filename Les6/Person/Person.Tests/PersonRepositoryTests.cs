using AutoFixture;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Tests
{
    internal class PersonRepositoryTests
    {
        private DbContextOptions<PersonDbContext> options;
        private Fixture fixture =  new Fixture();

        private PersonDbContext GetPersonDbContext()
        {
            return new PersonDbContext(options);
        }
        [SetUp]
        public void CreateDB()
        {
            DbConnection connection = new SqliteConnection("Filename=:memory:");
            connection.Open();

            options = new DbContextOptionsBuilder<PersonDbContext>().UseSqlite(connection).Options;


            PersonDbContext personDbContext = new PersonDbContext(options);
            personDbContext.Database.EnsureCreated();
        }

        [Test]
        public void GetAllPersons_WithNoPersons_ReturnsEmpty()
        {
            PersonRepository sut = new PersonRepository(GetPersonDbContext());


            List<Person> persons = sut.GetAllPersons();
            Assert.That(persons, Is.Empty);
        }

        [Test]
        public void GetAllPersons_WithPersons_ReturnsListOfPerson()
        {
            PersonDbContext context = GetPersonDbContext();


            List<Person> people = fixture
                .Build<Person>()
                .With(p => p.BirthDate, new DateTime(1995,1,1))
                .CreateMany<Person>(10).ToList();

            SeedDatabaseWithData(context, people);

            PersonRepository sut = new PersonRepository(context);

            List<Person> persons = sut.GetAllPersons();

            Assert.That(persons, Has.Count.EqualTo(10));
        }

        [Test]
        public void AddPerson_WithPerson_AddsPerson()
        {
            // Arrange
            PersonDbContext context = GetPersonDbContext();
            PersonRepository sut = new PersonRepository(context);
            Person p = fixture.Build<Person>().With(p=> p.LastName, "Doe").Create();

            // Act
            sut.AddPerson(p);

            // Assert
            Assert.That(context.Persons.First(), Is.EqualTo(p));
        }

        private void SeedDatabaseWithData(PersonDbContext personDbContext, List<Person> persons)
        {
            personDbContext.AddRange(persons);
            personDbContext.SaveChanges();  
        }
    }
}
