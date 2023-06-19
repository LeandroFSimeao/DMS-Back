using AutoMapper;
using DMS.Data.Dtos;
using DMS.Models;

namespace DMS.Profiles
{
    public class ItemPedidoProfile : Profile
    {
        public ItemPedidoProfile()
        {
            CreateMap<ItemPedidoDTO, Item_pedido>();
            CreateMap<Item_pedido, ItemPedidoDTO>();
        }
    }
}
