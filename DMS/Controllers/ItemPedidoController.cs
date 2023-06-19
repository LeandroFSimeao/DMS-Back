using DMS.Data.Dtos;
using DMS.Services.Interfaces;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace DMS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemPedidoController : ControllerBase
    {
        private IItemPedidoService _itemPedidoService;

        public ItemPedidoController(IItemPedidoService itemPedidoService)
        {
            _itemPedidoService = itemPedidoService;
        }

        [HttpPost]
        public IActionResult AdicionarItemPedido(ItemPedidoDTO dto)
        {

            ItemPedidoDTO readDTO = _itemPedidoService.Create(dto);
            return CreatedAtAction(nameof(RecuperaItemPedidoPorId), new { Id = readDTO.IdItemPedido }, readDTO);

        }

        [HttpGet]
        public IActionResult RecuperaItemPedidos()
        {
            List<ItemPedidoDTO> readDTO = _itemPedidoService.GetAll();
            if (readDTO != null) return Ok(readDTO);
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaItemPedidoPorId(int id)
        {

            ItemPedidoDTO readDTO = _itemPedidoService.GetById(id);
            if (readDTO == null) return NotFound();
            return Ok(readDTO);

        }

        [HttpPut]
        public IActionResult AtualizaItemPedido(ItemPedidoDTO dto)
        {

            Result resultado = _itemPedidoService.Update(dto);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]

        public IActionResult DeletaItemPedido(int id)
        {

            Result resultado = _itemPedidoService.DeleteById(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
