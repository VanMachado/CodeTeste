using CodeChallenge.Models;

namespace CodeChallenge.Data
{
    public class SeedingService
    {
        private MySqlContext _context;

        public SeedingService(MySqlContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Persons.Any() || _context.Enterprises.Any())
                return;

            Person p0 = new Person("John Cena", "john@gmail.com", "11 99645-7858", new DateTime(2024, 02, 15), false);
            Person p1 = new Person("Maria Silva", "maria@gmail.com", "11 98765-4321", new DateTime(1990, 05, 20), true);
            Person p2 = new Person("Carlos Oliveira", "carlos@gmail.com", "11 95432-1876", new DateTime(1985, 10, 12), false);

            Enterprise e0 = new Enterprise("Coca-Cola Company", "coca-cola@company.com", "11 98765-4321", new DateTime(1892, 01, 29), false);
            Enterprise e1 = new Enterprise("Amazon Inc.", "amazon@inc.com", "11 99645-7858", new DateTime(1994, 07, 05), true);
            Enterprise e2 = new Enterprise("Microsoft Corporation", "microsoft@corporation.com", "11 95432-1876", new DateTime(1975, 04, 04), false);

            _context.Persons.AddRange(p0, p1, p2);
            _context.Enterprises.AddRange(e0, e1, e2);
            _context.SaveChanges();
        }
    }
}
