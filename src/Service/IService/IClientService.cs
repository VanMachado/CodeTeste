using CodeChallenge.Models;

namespace CodeChallenge.Service.IService
{
    public interface IClientService
    {
        Task<List<Client>> Findall();
        Task<Client> FindById(int id);
        Task<Client> Update(Client client);
        Task Create(Client cliente);        
        Task<IEnumerable<Client>> Filter(string? nome, string? email, string? fone, DateTime? data, bool? blocked);
    }
}
