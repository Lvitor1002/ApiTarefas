
/*
(Servirá de modelo para outra classe) 
Uma interface especifíca os;
                            nomes e assinaturas de métodos, 
                            propriedades ou eventos, 
mas não implementa o comportamento — isso fica por conta das classes que a implementam.*/

using SistemaTarefas.Models;

namespace SistemaTarefas.Repository.Interfaces
{
    public interface ITarefaRepository
    {
        Task<List<TarefaModel >> BuscarTodasTarefas();
        Task<TarefaModel > BuscarPorId(int id);
        Task<TarefaModel > AdicionarTarefa(TarefaModel tarefa);
        Task<TarefaModel > AtualizarTarefa(TarefaModel tarefa, int id);
        Task<bool> ApagarTarefa(int id);
    }
}
