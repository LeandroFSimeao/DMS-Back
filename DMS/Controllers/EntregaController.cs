using DMS.Data.Dtos;
using DMS.Services.Interfaces;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace DMS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntregaController : ControllerBase
    {
        private IEntregaService _entregaService;

        public EntregaController(IEntregaService entregaService)
        {
            _entregaService = entregaService;
        }

        [HttpPost]
        public IActionResult AdicionarEntrega(EntregaDTO dto)
        {

            EntregaDTO readDTO = _entregaService.Create(dto);
            return CreatedAtAction(nameof(RecuperaEntregaPorId), new { Id = readDTO.IdEntrega }, readDTO);

        }

        [HttpGet]
        public IActionResult RecuperaEntregas()
        {
            List<EntregaDTO> readDTO = _entregaService.GetAll();
            if (readDTO != null) return Ok(readDTO);
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaEntregaPorId(int id)
        {

            EntregaDTO readDTO = _entregaService.GetById(id);
            if (readDTO == null) return NotFound();
            return Ok(readDTO);

        }

        [HttpPut]
        public IActionResult AtualizaEntrega(EntregaDTO dto)
        {

            Result resultado = _entregaService.Update(dto);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]

        public IActionResult DeletaEntrega(int id)
        {

            Result resultado = _entregaService.DeleteById(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
