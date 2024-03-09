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

        public async Task<IEnumerable<Client>> Findall()
        {
            return await _context.Clients.ToListAsync();
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
    }
}
