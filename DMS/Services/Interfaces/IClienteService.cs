using DMS.Data.Dtos;
using FluentResults;

namespace DMS.Services.Interfaces
{
    public interface IClienteService
    {
        ClienteDTO Create(ClienteDTO dto);
        Result DeleteById(int id);
        List<ClienteDTO> GetAll();
        ClienteDTO GetById(int id);
        Result Update(ClienteDTO dto);
    }
}
