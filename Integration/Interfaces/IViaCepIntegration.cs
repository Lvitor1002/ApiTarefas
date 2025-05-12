using SistemaTarefas.Integration.Response;

namespace SistemaTarefas.Integration.Interfaces
{
    public interface IViaCepIntegration
    {
        Task<ViaCepResponse> ObterDadosViaCep(string cep);
    }
}
