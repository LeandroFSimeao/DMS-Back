using AutoMapper;
using DMS.Data.Dtos;
using DMS.Models;

namespace DMS.Profiles
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<ClienteDTO, Cliente>();
            CreateMap<Cliente, ClienteDTO>();
        }
    }
}
