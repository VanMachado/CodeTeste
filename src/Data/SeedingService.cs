using CodeChallenge.Models;
using CodeChallenge.Models.Enums;

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
            if (_context.Clients.Any())
                return;

            Client p0 = new Client("John Cena", "joaocena@gmail.com", "11996457858", Tipo.Fisica, "12345678911", true, Genero.Masculino, new DateTime(1998, 06, 05), false, "12345678");
            Client p1 = new Client("Poco Yo", "pocoyo@gmail.com", "11996457859", Tipo.Juridica, "01123123000114", false, "012345678912");
            Client p2 = new Client("Maria Silva", "maria@gmail.com", "11987654321", Tipo.Fisica, "98765432199", true, Genero.Feminino, new DateTime(1990, 3, 15), false, "senha123");
            Client p3 = new Client("Empresa XYZ LTDA", "contato@empresa.xyz", "1112345678", Tipo.Juridica, "0154962192654", false, "112233440001");
            Client p4 = new Client("João Oliveira", "joao.oliveira@gmail.com", "11987651235", Tipo.Fisica, "12345678912", false, Genero.Masculino, new DateTime(1985, 7, 20), false, "abcd1234");
            Client p5 = new Client("Fernanda Santos", "fernanda.santos@gmail.com", "11987659877", Tipo.Fisica, "98765432123", true, Genero.Feminino, new DateTime(1978, 9, 10), true, "senha456");
            Client p6 = new Client("Empresa ABC Ltda", "contato@empresaabc.com.br", "1143218765", Tipo.Juridica, "12345678910214", true);
            Client p7 = new Client("Michael Jordan", "mjordan@gmail.com", "11976543210", Tipo.Fisica, "10987654321", false, Genero.Masculino, new DateTime(1963, 2, 17), false, "mjordan123");
            Client p8 = new Client("Empresa EFG Ltda", "contato@empresaefg.com", "1143218760", Tipo.Juridica, "13579246802468", false, "123456789012");
            Client p9 = new Client("Carla Souza", "carla.souza@gmail.com", "11987659876", Tipo.Fisica, "98765432123", true, Genero.Feminino, new DateTime(1987, 5, 25), true, "senha789");
            Client p10 = new Client("Pedro Almeida", "pedro.almeida@gmail.com", "11987651234", Tipo.Fisica, "12345678912", false, Genero.Masculino, new DateTime(1990, 11, 30), false, "pedro123456");
            Client p11 = new Client("Empresa QRS LTDA", "contato@empresaqrs.com", "1112345678", Tipo.Juridica, "98765432101236", false, "654321987012");
            Client p12 = new Client("Mariana Oliveira", "mariana.oliveira@gmail.com", "11987654321", Tipo.Fisica, "98765432198", true, Genero.Feminino, new DateTime(1983, 8, 8), false, "mariana987");
            Client p13 = new Client("Empresa UV Ltda", "contato@empresauv.com", "1143218767", Tipo.Juridica, "25896314702584", false, "789456123012");
            Client p14 = new Client("Gabriel Silva", "gabriel.silva@gmail.com", "11976543210", Tipo.Fisica, "01234567890", false, Genero.Masculino, new DateTime(1989, 4, 20), false, "gabriel123");
            Client p15 = new Client("Empresa XYZ LTDA", "contato@empresa.xyz", "1112345678", Tipo.Juridica, "15975362478521", false, "112233445566");
            Client p16 = new Client("Ana Lima", "ana.lima@gmail.com", "11987659876", Tipo.Fisica, "98765432123", true, Genero.Feminino, new DateTime(1975, 12, 15), true, "ana123");
            Client p17 = new Client("Empresa UVW LTDA", "contato@empresauvw.com", "1143218765", Tipo.Juridica, "75395145678924", false, "789123456012");
            Client p18 = new Client("Lucas Costa", "lucas.costa@gmail.com", "11987651234", Tipo.Fisica, "12345678912", false, Genero.Masculino, new DateTime(1980, 6, 3), false, "lucas123456");


            _context.Clients.AddRange(p0, p1, p2, p3, p4, p5, p6, p7,
                p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18);

            _context.SaveChanges();
        }
    }
}
