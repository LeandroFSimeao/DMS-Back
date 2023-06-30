using DMS.Data.Dtos;
using DMS.Services.Interfaces;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace DMS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        public IActionResult AdicionarCliente(ClienteDTO dto) {

            ClienteDTO readDTO = _clienteService.Create(dto);
            return CreatedAtAction(nameof(RecuperaClientePorId), new { Id = readDTO.IdCliente }, readDTO);

        }

        [HttpGet]
        public IActionResult RecuperaClientes()
        {
            List<ClienteDTO> readDTO = _clienteService.GetAll();
            if (readDTO !=null) return Ok(readDTO);
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaClientePorId(int id) {

            ClienteDTO readDTO = _clienteService.GetById(id);
            if (readDTO == null) return NotFound();
            return Ok(readDTO);

        }

        [HttpPut]
        public IActionResult AtualizaCliente(ClienteDTO dto)
        {

            Result resultado = _clienteService.Update(dto);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]

        public IActionResult DeletaCliente(int id) {

            Result resultado = _clienteService.DeleteById(id);
            if(resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpPatch("Geocodifica/{clienteId}")]
        public async Task<IActionResult> GeocodificaCliente(int clienteId)
        {
            ClienteDTO readDTO = await _clienteService.GeocodificaCliente(clienteId);
            if (readDTO == null) return NotFound();
            return Ok(readDTO);
        }
    }
}
