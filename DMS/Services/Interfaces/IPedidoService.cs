using DMS.Data.Dtos;
using FluentResults;

namespace DMS.Services.Interfaces
{
    public interface IPedidoService
    {
        PedidoDTO Create(PedidoDTO dto);
        Result DeleteById(int id);
        List<PedidoDTO> GetAll();
        PedidoDTO GetById(int id);
        Result Update(PedidoDTO dto);
    }
}
