using AutoMapper;
using DMS.Data.Dtos;
using DMS.Data;
using DMS.Models;
using DMS.Repositories.Interfaces;
using FluentResults;

namespace DMS.Repositories
{
    public class ItemPedidoRepository : IItemPedidoRepository
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public ItemPedidoRepository(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public ItemPedidoDTO Create(ItemPedidoDTO dto)
        {
            Item_pedido itemPedido = _mapper.Map<Item_pedido>(dto);

            _context.ItensPedido.Add(itemPedido);
            _context.SaveChanges();

            return _mapper.Map<ItemPedidoDTO>(itemPedido);
        }

        public ItemPedidoDTO GetById(int id)
        {
            Item_pedido itemPedido = _context.ItensPedido.FirstOrDefault(itemPedido => itemPedido.IdItemPedido == id);
            if (itemPedido != null)
            {
                ItemPedidoDTO itemPedidoDTO = _mapper.Map<ItemPedidoDTO>(itemPedido);

                return itemPedidoDTO;
            }
            return null;
        }

        public List<ItemPedidoDTO> GetAll()
        {
            List<Item_pedido> itemPedidos = _context.ItensPedido.ToList();

            if (itemPedidos != null)
            {
                List<ItemPedidoDTO> readDTO = _mapper.Map<List<ItemPedidoDTO>>(itemPedidos);
                return readDTO;
            }

            return null;
        }

        public Result Update(ItemPedidoDTO dto)
        {
            Item_pedido itemPedidos = _context.ItensPedido.FirstOrDefault(itemPedidos => itemPedidos.IdItemPedido == dto.IdItemPedido);
            if (itemPedidos == null)
            {
                return Result.Fail("ItemPedido não encontrado");
            }

            _mapper.Map(dto, itemPedidos);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeleteById(int id)
        {
            Item_pedido itemPedidos = _context.ItensPedido.FirstOrDefault(itemPedidos => itemPedidos.IdItemPedido == id);
            if (itemPedidos == null)
            {
                return Result.Fail("ItemPedido não encontrado");
            }

            _context.Remove(itemPedidos);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
