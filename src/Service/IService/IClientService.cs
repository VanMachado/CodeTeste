using CodeChallenge.Models;
using CodeChallenge.Models.Dto;

namespace CodeChallenge.Service.IService
{
    public interface IClientService
    {
        Task<List<ClientDto>> Findall(string token);
        Task<ClientDto> FindById(int id, string token);
        Task<ClientDto> Update(ClientDto client, string token);
        Task Create(ClientDto cliente, string token);        
        Task<IEnumerable<ClientDto>> Filter(string? nome, string? email, string? fone, DateTime? data, bool? blocked, string token);
    }
}
