using DMS.Data.Dtos;
using FluentResults;

namespace DMS.Services.Interfaces
{
    public interface IClienteService
    {
        ClienteDTO Create(ClienteDTO dto);
        FluentResults.Result DeleteById(int id);
        Task<ClienteDTO> GeocodificaCliente(int clienteId);
        List<ClienteDTO> GetAll();
        ClienteDTO GetById(int id);
        FluentResults.Result Update(ClienteDTO dto);
    }
}
