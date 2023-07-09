using DMS.Data.Dtos;
using DMS.Repositories.Interfaces;
using DMS.Services.Interfaces;
using FluentResults;

namespace DMS.Services
{
    public class ClienteService : IClienteService
    {
        private IGoogleApiHelper _googleApiHelper;
        private IClienteRepository _clienteRepository;
        public ClienteService(IClienteRepository clienteRepository, IGoogleApiHelper googleApiHelper)
        {
            _clienteRepository = clienteRepository;
            _googleApiHelper = googleApiHelper;
        }
        public ClienteDTO Create(ClienteDTO dto) => _clienteRepository.Create(dto);
        public FluentResults.Result DeleteById(int id) => _clienteRepository.DeleteById(id);

        public async Task<ClienteDTO> GeocodificaCliente(int clienteId)
        {
            ClienteDTO cliente = GetById(clienteId);
            GeoCodeResponse response = await _googleApiHelper.Geocoding(cliente.Logradouro +", "+ cliente.Numero);
            cliente.Latitude = response.results[0].geometry.location.lat.ToString();
            cliente.Longitude = response.results[0].geometry.location.lng.ToString();
            Update(cliente);
            return cliente;
        }

        public List<ClienteDTO> GetAll() {
            try
            {
            return _clienteRepository.GetAll();

            }catch (Exception ex)
            {
                throw ex;
            }
        } 
        public ClienteDTO GetById(int id) =>  _clienteRepository.GetById(id);
        public FluentResults.Result Update(ClienteDTO dto) => _clienteRepository.Update(dto);
    }
}
