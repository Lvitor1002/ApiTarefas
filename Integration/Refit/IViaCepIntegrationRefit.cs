using Refit;
using SistemaTarefas.Integration.Response;

namespace SistemaTarefas.Integration.Refit
{
    public interface IViaCepIntegrationRefit 
    {
        [Get("/ws/{cep}/json/")]
        Task<ApiResponse<ViaCepResponse>> ObterDadosViaCep(string cep);
    }
}
