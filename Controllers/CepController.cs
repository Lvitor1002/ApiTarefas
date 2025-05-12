using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaTarefas.Integration.Interfaces;
using SistemaTarefas.Integration.Response;

namespace SistemaTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CepController : ControllerBase
    {
        private readonly IViaCepIntegration _viaCepIntegration;

        public CepController(IViaCepIntegration viaCepIntegration)
        {
            _viaCepIntegration = viaCepIntegration;
        }
        [HttpGet]
        public async Task<ActionResult<ViaCepResponse>> ListarDadosCep(string cep)
        {
            var resposta = await _viaCepIntegration.ObterDadosViaCep(cep);

            if (resposta == null)
            {
                return BadRequest("Cep não encontrado!");
            }
            return Ok(resposta);
        }
    }
    
    
}
