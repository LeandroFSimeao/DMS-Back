using DMS.Data.Dtos;
using FluentResults;

namespace DMS.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        ClienteDTO Create(ClienteDTO dto);
        Result DeleteById(int id);
        List<ClienteDTO> GetAll();
        ClienteDTO GetById(int id);
        Result Update(ClienteDTO dto);
    }
}
