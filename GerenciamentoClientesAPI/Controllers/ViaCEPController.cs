using GerenciamentoClientesAPI.Services.ViaCEP;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoClientesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ViaCEPController : ControllerBase
    {
        private readonly IViaCEPService _viaCEPService;
        public ViaCEPController(IViaCEPService viaCEPService)
        {
            _viaCEPService = viaCEPService;
        }

        [HttpGet("{cep}")]
        public async Task<ActionResult<Endereco>> GetEnderecoPorCEP(string cep)
        {
            if (!IsValidCEP(cep))
            {
                return BadRequest("CEP inválido.");
            }

            var endereco = await _viaCEPService.ConsultarEnderecoPorCEPAsync(cep);

            if (endereco == null)
            {
                return NotFound("Endereço não encontrado.");
            }

            return Ok(endereco);
        }

        private bool IsValidCEP(string cep)
        {
            return !string.IsNullOrEmpty(cep) && cep.Length == 8;
        }
    }
}
