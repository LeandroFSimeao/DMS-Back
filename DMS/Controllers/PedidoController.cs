using DMS.Data.Dtos;
using DMS.Services.Interfaces;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace DMS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        private IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpPost]
        public IActionResult AdicionarPedido(PedidoDTO dto)
        {

            PedidoDTO readDTO = _pedidoService.Create(dto);
            return CreatedAtAction(nameof(RecuperaPedidoPorId), new { Id = readDTO.IdPedido }, readDTO);

        }

        [HttpGet]
        public IActionResult RecuperaPedidos()
        {
            List<PedidoDTO> readDTO = _pedidoService.GetAll();
            if (readDTO != null) return Ok(readDTO);
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaPedidoPorId(int id)
        {

            PedidoDTO readDTO = _pedidoService.GetById(id);
            if (readDTO == null) return NotFound();
            return Ok(readDTO);

        }

        [HttpPut]
        public IActionResult AtualizaPedido(PedidoDTO dto)
        {

            Result resultado = _pedidoService.Update(dto);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]

        public IActionResult DeletaPedido(int id)
        {

            Result resultado = _pedidoService.DeleteById(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
