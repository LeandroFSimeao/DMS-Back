using DMS.Data.Dtos;
using FluentResults;

namespace DMS.Repositories.Interfaces
{
    public interface IPedidoRepository
    {
        PedidoDTO Create(PedidoDTO dto);
        Result DeleteById(int id);
        List<PedidoDTO> GetAll();
        PedidoDTO GetById(int id);
        Result Update(PedidoDTO dto);
    }
}
