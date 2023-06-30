using DMS.Data.Dtos;
using FluentResults;

namespace DMS.Services.Interfaces
{
    public interface IEntregaService
    {
        EntregaDTO Create(EntregaDTO dto);
        Result DeleteById(int id);
        Task<EntregaDTO> GerarEntregaOtimizada(List<int> idPedidos);
        List<EntregaDTO> GetAll();
        EntregaDTO GetById(int id);
        Result Update(EntregaDTO dto);
    }
}
