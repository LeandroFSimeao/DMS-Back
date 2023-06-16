using AutoMapper;
using DMS.Data.Dtos;
using DMS.Models;

namespace DMS.Profiles
{
    public class EntregaProfile : Profile
    {
        public EntregaProfile()
        {
            CreateMap<EntregaDTO, Entrega>();
            CreateMap<Entrega, EntregaDTO>();
        }
    }
}
