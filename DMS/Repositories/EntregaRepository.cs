using AutoMapper;
using DMS.Data.Dtos;
using DMS.Data;
using DMS.Models;
using DMS.Repositories.Interfaces;
using FluentResults;

namespace DMS.Repositories
{
    public class EntregaRepository : IEntregaRepository
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public EntregaRepository(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public EntregaDTO Create(EntregaDTO dto)
        {
            Entrega entrega = _mapper.Map<Entrega>(dto);

            _context.Entregas.Add(entrega);
            _context.SaveChanges();

            return _mapper.Map<EntregaDTO>(entrega);
        }

        public EntregaDTO GetById(int id)
        {
            Entrega entrega = _context.Entregas.FirstOrDefault(entrega => entrega.IdEntrega == id);
            if (entrega != null)
            {
                EntregaDTO entregaDTO = _mapper.Map<EntregaDTO>(entrega);

                return entregaDTO;
            }
            return null;
        }

        public List<EntregaDTO> GetAll()
        {
            List<Entrega> entregas = _context.Entregas.ToList();

            if (entregas != null)
            {
                List<EntregaDTO> readDTO = _mapper.Map<List<EntregaDTO>>(entregas);
                return readDTO;
            }

            return null;
        }

        public Result Update(EntregaDTO dto)
        {
            Entrega entregas = _context.Entregas.FirstOrDefault(entregas => entregas.IdEntrega == dto.IdEntrega);
            if (entregas == null)
            {
                return Result.Fail("Entrega não encontrado");
            }

            _mapper.Map(dto, entregas);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeleteById(int id)
        {
            Entrega entregas = _context.Entregas.FirstOrDefault(entregas => entregas.IdEntrega == id);
            if (entregas == null)
            {
                return Result.Fail("Entrega não encontrado");
            }

            _context.Remove(entregas);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
