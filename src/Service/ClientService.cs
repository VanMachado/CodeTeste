using CodeChallenge.Data;
using CodeChallenge.Models;
using CodeChallenge.Service.IService;
using Microsoft.EntityFrameworkCore;

namespace CodeChallenge.Service
{
    public class ClientService : IClientService
    {
        private readonly MySqlContext _context;

        public ClientService(MySqlContext context)
        {
            _context = context;
        }

        public async Task<List<Client>> Findall()
        {
            return await _context.Clients.ToListAsync();
        }
        
        public async Task<Client> FindById(int id)
        {
            return await _context.Clients.Where(c => c.Id == id).FirstOrDefaultAsync();            
        }

        public async Task<Client> Update(Client client)
        {
            _context.Clients.Update(client);
            await _context.SaveChangesAsync();

            return client;
        }

        public async Task Create(Client cliente)
        {
            if (await _context.Clients.Where(c => c.CpfOuCnpj == cliente.CpfOuCnpj).FirstOrDefaultAsync() != null)
                throw new Exception("Este CPF/CNPJ já está cadastrado para outro Cliente");
            if (await _context.Clients.Where(c => c.Email == cliente.Email).FirstOrDefaultAsync() != null)
                throw new Exception("Este e-mail já está cadastrado para outro Cliente");
            if (!cliente.Insento && await _context.Clients.Where(c => c.Inscricao == cliente.Inscricao)
                .FirstOrDefaultAsync() != null)
                throw new Exception("Esta Inscrição Estadual já está cadastrada para outro Cliente");
            if (cliente.Senha != cliente.ConfirmacaoSenha)
                throw new Exception("Senhas não coincidem");

            _context.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Client>> Filter(string? nome, string? email, string? fone, DateTime? data, bool? blocked)
        {                    
            if(nome != null)
                return await _context.Clients.Where(c => c.Nome == nome).ToListAsync();
            if(email != null)
                return await _context.Clients.Where(c => c.Email == email).ToListAsync();
            if (fone != null)
                return await _context.Clients.Where(c => c.Fone == fone).ToListAsync();            
            if (data != null)
                return await _context.Clients.Where(c => c.DataRegistro == data).ToListAsync();
            if (blocked != null)
                return await _context.Clients.Where(c => c.ClientBlocked == blocked).ToListAsync();

            throw new Exception("Cliente não encontrado");
        }
    }
}
