using CodeChallenge.Models;
using CodeChallenge.Models.Dto;

namespace CodeChallenge.Service.IService
{
    public interface IClientService
    {
        Task<List<ClientDto>> Findall();
        Task<ClientDto> FindById(int id);
        Task<ClientDto> Update(ClientDto client);
        Task Create(ClientDto cliente);        
        Task<IEnumerable<ClientDto>> Filter(string? nome, string? email, string? fone, DateTime? data, bool? blocked);
    }
}
