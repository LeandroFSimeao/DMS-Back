using DMS.Data.Dtos;
using FluentResults;

namespace DMS.Repositories.Interfaces
{
    public interface IEntregaRepository
    {
        EntregaDTO Create(EntregaDTO dto);
        Result DeleteById(int id);
        List<EntregaDTO> GetAll();
        EntregaDTO GetById(int id);
        Result Update(EntregaDTO dto);
    }
}
