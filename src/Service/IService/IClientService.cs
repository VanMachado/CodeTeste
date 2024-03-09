using CodeChallenge.Models;

namespace CodeChallenge.Service.IService
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> Findall();
        Task Create(Client cliente);             
    }
}
