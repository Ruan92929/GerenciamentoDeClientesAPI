using GerenciamentoClientesAPI.Models;
using GerenciamentoClientesAPI.Services.Clientes;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoClientesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> ListarClientes(int pagina = 1, int tamanhoPagina = 10)
        {
            var clientes = await _clienteService.ListarClientesAsync(pagina, tamanhoPagina);
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> ObterClientePorId(int id)
        {
            var cliente = await _clienteService.ObterClientePorIdAsync(id);
            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CriarCliente(Cliente cliente)
        {
            var idCliente = await _clienteService.CriarClienteAsync(cliente);
            return Ok(idCliente);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> AtualizarCliente(int id, Cliente cliente)
        {
            await _clienteService.AtualizarClienteAsync(id, cliente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> ExcluirCliente(int id)
        {
            await _clienteService.ExcluirClienteAsync(id);
            return NoContent();
        }
    }

}
