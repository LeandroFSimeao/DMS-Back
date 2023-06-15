using DMS.Data.Dtos;
using DMS.Repositories.Interfaces;
using DMS.Services.Interfaces;
using FluentResults;

namespace DMS.Services
{
    public class ClienteService : IClienteService
    {
        private IClienteRepository _clienteRepository;
        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public ClienteDTO Create(ClienteDTO dto) => _clienteRepository.Create(dto);
        public Result DeleteById(int id) => _clienteRepository.DeleteById(id);      
        public List<ClienteDTO> GetAll() => _clienteRepository.GetAll();
        public ClienteDTO GetById(int id) =>  _clienteRepository.GetById(id);
        public Result Update(ClienteDTO dto) => _clienteRepository.Update(dto);
    }
}
