using AutoMapper;
using CodeChallenge.Data;
using CodeChallenge.Models;
using CodeChallenge.Models.Dto;
using CodeChallenge.Models.Dto.EnumsDto;
using CodeChallenge.Service.IService;
using Microsoft.EntityFrameworkCore;

namespace CodeChallenge.Service
{
    public class ClientService : IClientService
    {
        private readonly MySqlContext _context;
        private readonly IMapper _mapper;

        public ClientService(MySqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ClientDto>> Findall()
        {
            var clients = await _context.Clients.ToListAsync();
            
            return _mapper.Map<List<ClientDto>>(clients);
        }
        
        public async Task<ClientDto> FindById(int id)
        {
            var client = await _context.Clients.Where(c => c.Id == id).FirstOrDefaultAsync();

            return _mapper.Map<ClientDto>(client);
        }

        public async Task<ClientDto> Update(ClientDto client)
        {
            var cliente = _mapper.Map<Client>(client);
            
            _context.Clients.Update(cliente);
            await _context.SaveChangesAsync();

            return client;
        }

        public async Task Create(ClientDto client)
        {
            if (await _context.Clients.Where(c => c.CpfOuCnpj == client.CpfOuCnpj).FirstOrDefaultAsync() != null)
                throw new Exception("Este CPF/CNPJ já está cadastrado para outro Cliente");
            if (await _context.Clients.Where(c => c.Fone == client.Fone).FirstOrDefaultAsync() != null)
                throw new Exception("Este telefone já está cadastrado para outro Cliente");
            if (client.CpfOuCnpj.Length > 11 && client.Tipo == TipoDto.Fisica)
                throw new Exception("Insira um numero de CPF válido");
            if (client.CpfOuCnpj.Length < 14 && client.Tipo == TipoDto.Juridica)
                throw new Exception("Insira um numero de CNPJ válido");
            if (await _context.Clients.Where(c => c.Email == client.Email).FirstOrDefaultAsync() != null)
                throw new Exception("Este e-mail já está cadastrado para outro Cliente");
            if (!client.Isento && client.Inscricao == null)
                throw new Exception("Preencha a Inscrição Estadual");
            if (!client.Isento && await _context.Clients.Where(c => c.Inscricao == client.Inscricao)
                .FirstOrDefaultAsync() != null)
                throw new Exception("Esta Inscrição Estadual já está cadastrada para outro Cliente");
            if (client.Senha != client.ConfirmacaoSenha)
                throw new Exception("Senhas não coincidem");
            
            var cliente = _mapper.Map<Client>(client);
            _context.Add(cliente);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ClientDto>> Filter(string? nome, string? email, string? fone, DateTime? data, bool? blocked)
        {                    
            if(nome != null)
            {
                var client = await _context.Clients.Where(c => c.Nome == nome).ToListAsync();
                return _mapper.Map<List<ClientDto>>(client);
            }                                           
            if(email != null)
            {                
                var client = await _context.Clients.Where(c => c.Email == email).ToListAsync();
                return _mapper.Map<List<ClientDto>>(client);
            }                
            if (fone != null)
            {
                var client = await _context.Clients.Where(c => c.Fone == fone).ToListAsync();
                return _mapper.Map<List<ClientDto>>(client);
            }             
            if (data != null)
            {
                var client = await _context.Clients.Where(c => c.DataRegistro == data).ToListAsync();
                return _mapper.Map<List<ClientDto>>(client);
            }                
            if (blocked != null)
            {
                var client = await _context.Clients.Where(c => c.ClientBlocked == blocked).ToListAsync();
                return _mapper.Map<List<ClientDto>>(client);
            }                

            throw new Exception("Cliente não encontrado");
        }
    }
}
