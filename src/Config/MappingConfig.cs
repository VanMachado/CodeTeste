using AutoMapper;
using CodeChallenge.Models;
using CodeChallenge.Models.Dto;

namespace CodeChallenge.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ClientDto, Client>().ReverseMap();                
            });

            return mappingConfig;
        }
    }
}
