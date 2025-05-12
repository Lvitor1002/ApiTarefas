using SistemaTarefas.Integration.Interfaces;
using SistemaTarefas.Integration.Refit;
using SistemaTarefas.Integration.Response;

namespace SistemaTarefas.Integration
{
    public class ViaCepIntegration : IViaCepIntegration
    {
        private readonly IViaCepIntegrationRefit _viaCepIntegrationRefit;

        public ViaCepIntegration(IViaCepIntegrationRefit viaCepIntegrationRefit)
        {
            _viaCepIntegrationRefit = viaCepIntegrationRefit;
        }
        public async Task<ViaCepResponse> ObterDadosViaCep(string cep)
        {
            var resposta = await _viaCepIntegrationRefit.ObterDadosViaCep(cep);

            if (resposta != null && resposta.IsSuccessStatusCode)
            {
                return resposta.Content;
            }
            return null;
        }
    }
}
