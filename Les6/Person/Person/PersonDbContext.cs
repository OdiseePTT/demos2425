using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HigherLowerGame
{
    public class PersonDbContext : DbContext
    {
        #region Public Constructors

       

        public PersonDbContext():base()
        {
            Database.EnsureCreated();
        }

        #endregion Public Constructors

        #region Properties

        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=PersonDB");
           
        }

        #endregion Properties



    }
}