using DMS.Data.Dtos;
using DMS.Repositories.Interfaces;
using DMS.Services.Interfaces;
using FluentResults;

namespace DMS.Services
{
    public class EntregaService : IEntregaService
    {
        private IEntregaRepository _entregaRepository;
        private IClienteService _clienteService;
        private IGoogleApiHelper _googleApiHelper;
        private IPedidoService _pedidoService;
        public EntregaService(IEntregaRepository entregaRepository, IClienteService clienteService, IGoogleApiHelper googleApiHelper, IPedidoService pedidoService)
        {
            _entregaRepository = entregaRepository;
            _clienteService = clienteService;
            _googleApiHelper = googleApiHelper;
            _pedidoService = pedidoService;
        }
        public EntregaDTO Create(EntregaDTO dto) => _entregaRepository.Create(dto);
        public Result DeleteById(int id) => _entregaRepository.DeleteById(id);

        public async Task<EntregaDTO> GerarEntregaOtimizada(List<int> idPedidos)
        {
            List<string> enderecos = new List<string>();

            foreach (var id in idPedidos)
            {
                PedidoDTO pedido = _pedidoService.GetById(id);
                ClienteDTO cliente = _clienteService.GetById(pedido.IdCliente);
                string endereco = cliente.Latitude.Replace(',','.')+","+cliente.Longitude.Replace(",",".");
                enderecos.Add(endereco);
            }
            EntregaDTO entregaDTO = await _googleApiHelper.GeraRotaOtimizada(enderecos);
            entregaDTO = Create(entregaDTO);

            return entregaDTO;
        }

        public List<EntregaDTO> GetAll() => _entregaRepository.GetAll();
        public EntregaDTO GetById(int id) => _entregaRepository.GetById(id);
        public Result Update(EntregaDTO dto) => _entregaRepository.Update(dto);
    }
}
