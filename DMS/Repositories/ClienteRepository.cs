using AutoMapper;
using DMS.Data;
using DMS.Data.Dtos;
using DMS.Models;
using DMS.Repositories.Interfaces;
using FluentResults;

namespace DMS.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public ClienteRepository(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public ClienteDTO Create(ClienteDTO dto)
        {
            Cliente cliente = _mapper.Map<Cliente>(dto);

            _context.Clientes.Add(cliente);
            _context.SaveChanges();

            return _mapper.Map<ClienteDTO>(cliente);
        }

        public ClienteDTO GetById(int id)
        {
            Cliente cliente = _context.Clientes.FirstOrDefault(cliente => cliente.IdCliente == id);
            if (cliente != null)
            {
                ClienteDTO clienteDTO = _mapper.Map<ClienteDTO>(cliente);

                return clienteDTO;
            }
            return null;
        }

        public List<ClienteDTO> GetAll()
        {
            try
            {
                List<Cliente> clientes = _context.Clientes.ToList();

                if (clientes != null)
                {
                    List<ClienteDTO> readDTO = _mapper.Map<List<ClienteDTO>>(clientes);
                    return readDTO;
                }

                return null;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Result Update(ClienteDTO dto)
        {
            Cliente clientes = _context.Clientes.FirstOrDefault(clientes => clientes.IdCliente == dto.IdCliente);
            if (clientes == null)
            {
                return Result.Fail("Cliente não encontrado");
            }

            _mapper.Map(dto, clientes);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeleteById(int id)
        {
            Cliente clientes = _context.Clientes.FirstOrDefault(clientes => clientes.IdCliente == id);
            if (clientes == null)
            {
                return Result.Fail("Cliente não encontrado");
            }

            _context.Remove(clientes);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
