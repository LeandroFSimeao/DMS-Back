using DMS.Data.Dtos;
using DMS.Repositories.Interfaces;
using DMS.Services.Interfaces;
using FluentResults;

namespace DMS.Services
{
    public class EntregaService : IEntregaService
    {
        private IEntregaRepository _entregaRepository;
        public EntregaService(IEntregaRepository entregaRepository)
        {
            _entregaRepository = entregaRepository;
        }
        public EntregaDTO Create(EntregaDTO dto) => _entregaRepository.Create(dto);
        public Result DeleteById(int id) => _entregaRepository.DeleteById(id);
        public List<EntregaDTO> GetAll() => _entregaRepository.GetAll();
        public EntregaDTO GetById(int id) => _entregaRepository.GetById(id);
        public Result Update(EntregaDTO dto) => _entregaRepository.Update(dto);
    }
}
