using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace NotesTakingApp.Data
{
    public class AppDbContext : DbContext, IDesignTimeDbContextFactory<AppDbContext>
    {

        public DbSet<Note> Notes { get; set; }

        public AppDbContext(DbContextOptions options):base(options)
        {
            
        }
        public AppDbContext()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLlocalDB;Database=NotesDB;");
            }
        }

        public AppDbContext CreateDbContext(string[] args)
        {
            return new AppDbContext();
        }
    }
}
