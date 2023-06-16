using AutoMapper;
using DMS.Data.Dtos;
using DMS.Models;

namespace DMS.Profiles
{
    public class PedidoProfile : Profile
    {
        public PedidoProfile()
        {
            CreateMap<PedidoDTO, Pedido>();
            CreateMap<Pedido, PedidoDTO>();
        }
    }
}
