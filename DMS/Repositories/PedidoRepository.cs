using AutoMapper;
using DMS.Data.Dtos;
using DMS.Data;
using DMS.Models;
using DMS.Repositories.Interfaces;
using FluentResults;

namespace DMS.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public PedidoRepository(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public PedidoDTO Create(PedidoDTO dto)
        {
            Pedido pedido = _mapper.Map<Pedido>(dto);

            _context.Pedidos.Add(pedido);
            _context.SaveChanges();

            return _mapper.Map<PedidoDTO>(pedido);
        }

        public PedidoDTO GetById(int id)
        {
            Pedido pedido = _context.Pedidos.FirstOrDefault(pedido => pedido.IdPedido == id);
            if (pedido != null)
            {
                PedidoDTO pedidoDTO = _mapper.Map<PedidoDTO>(pedido);

                return pedidoDTO;
            }
            return null;
        }

        public List<PedidoDTO> GetAll()
        {
            List<Pedido> pedidos = _context.Pedidos.ToList();

            if (pedidos != null)
            {
                List<PedidoDTO> readDTO = _mapper.Map<List<PedidoDTO>>(pedidos);
                return readDTO;
            }

            return null;
        }

        public Result Update(PedidoDTO dto)
        {
            Pedido pedidos = _context.Pedidos.FirstOrDefault(pedidos => pedidos.IdPedido == dto.IdPedido);
            if (pedidos == null)
            {
                return Result.Fail("Pedido não encontrado");
            }

            _mapper.Map(dto, pedidos);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeleteById(int id)
        {
            Pedido pedidos = _context.Pedidos.FirstOrDefault(pedidos => pedidos.IdPedido == id);
            if (pedidos == null)
            {
                return Result.Fail("Pedido não encontrado");
            }

            _context.Remove(pedidos);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
