using CodeChallenge.Data.IData;
using CodeChallenge.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeChallenge.Data
{
    public class MySqlContext : DbContext, IDbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options)
               : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Enterprise> Enterprises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Enterprise>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
