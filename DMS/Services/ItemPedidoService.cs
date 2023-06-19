using DMS.Data.Dtos;
using DMS.Repositories.Interfaces;
using DMS.Services.Interfaces;
using FluentResults;

namespace DMS.Services
{
    public class ItemPedidoService : IItemPedidoService
    {
        private IItemPedidoRepository _itemPedidoRepository;
        public ItemPedidoService(IItemPedidoRepository itemPedidoRepository)
        {
            _itemPedidoRepository = itemPedidoRepository;
        }
        public ItemPedidoDTO Create(ItemPedidoDTO dto) => _itemPedidoRepository.Create(dto);
        public Result DeleteById(int id) => _itemPedidoRepository.DeleteById(id);
        public List<ItemPedidoDTO> GetAll() => _itemPedidoRepository.GetAll();
        public ItemPedidoDTO GetById(int id) => _itemPedidoRepository.GetById(id);
        public Result Update(ItemPedidoDTO dto) => _itemPedidoRepository.Update(dto);
    }
}
