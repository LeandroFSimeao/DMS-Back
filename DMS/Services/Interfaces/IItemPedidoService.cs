using DMS.Data.Dtos;
using FluentResults;

namespace DMS.Services.Interfaces
{
    public interface IItemPedidoService
    {
        ItemPedidoDTO Create(ItemPedidoDTO dto);
        Result DeleteById(int id);
        List<ItemPedidoDTO> GetAll();
        ItemPedidoDTO GetById(int id);
        Result Update(ItemPedidoDTO dto);
    }
}
