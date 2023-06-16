using DMS.Data.Dtos;
using DMS.Repositories.Interfaces;
using DMS.Services.Interfaces;
using FluentResults;

namespace DMS.Services
{
    public class PedidoService : IPedidoService
    {
        private IPedidoRepository _pedidoRepository;
        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }
        public PedidoDTO Create(PedidoDTO dto) => _pedidoRepository.Create(dto);
        public Result DeleteById(int id) => _pedidoRepository.DeleteById(id);
        public List<PedidoDTO> GetAll() => _pedidoRepository.GetAll();
        public PedidoDTO GetById(int id) => _pedidoRepository.GetById(id);
        public Result Update(PedidoDTO dto) => _pedidoRepository.Update(dto);
    }
}
