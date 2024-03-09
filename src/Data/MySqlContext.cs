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

        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Client>()
                .Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(150);

            modelBuilder.Entity<Client>()
                .Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(150);

            modelBuilder.Entity<Client>()
              .Property(p => p.Fone)
              .IsRequired()
              .HasMaxLength(11);

            modelBuilder.Entity<Client>()
             .Property(p => p.Tipo)
             .IsRequired();

            modelBuilder.Entity<Client>()
              .Property(p => p.CpfOuCnpj)
              .IsRequired()
              .HasMaxLength(14);

            modelBuilder.Entity<Client>()
              .Property(p => p.Inscricao)
              .HasMaxLength(12);

            modelBuilder.Entity<Client>()
              .Property(p => p.Senha)
              .HasMaxLength(12);
        }
    }
}
