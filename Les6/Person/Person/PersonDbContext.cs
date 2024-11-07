using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Person
{
    public class PersonDbContext : DbContext, IDesignTimeDbContextFactory<PersonDbContext>
    {
        #region Public Constructors

        public PersonDbContext(DbContextOptions<PersonDbContext> options): base(options)
        {
            
        }

        public PersonDbContext():base()
        {
            Database.EnsureCreated();
        }

        #endregion Public Constructors

        #region Properties

        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=PersonDB");
            }
        }

        public PersonDbContext CreateDbContext(string[] args)
        {
            return new PersonDbContext();
        }

        #endregion Properties



    }
}