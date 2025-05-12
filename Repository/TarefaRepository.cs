
using Microsoft.EntityFrameworkCore;
using SistemaTarefas.Data;
using SistemaTarefas.Models;
using SistemaTarefas.Repository.Interfaces;


namespace SistemaTarefas.Repository
{
    public class TarefaRepository : ITarefaRepository
    {
        //Atributo
        private readonly SistemaTarefasDB _dbContext;


        //Construtor
        public TarefaRepository(SistemaTarefasDB sistemaTarefasDB)
        { 
            _dbContext = sistemaTarefasDB;
        }


        //Métodos
        public async Task<TarefaModel > BuscarPorId(int id)
        {
            //Retorna, além da tarefa, os detalhes do include(usuário) do usuário vinculado
            return await _dbContext.Tarefas.Include(u => u.Usuario).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<TarefaModel >> BuscarTodasTarefas()
        {
            //Retorna, além de todas as tarefa, os detalhes do include(usuário) do usuário vinculado
            return await _dbContext.Tarefas.Include(u => u.Usuario).ToListAsync();
        }

        public async Task<TarefaModel > AdicionarTarefa(TarefaModel tarefa)
        {
            await _dbContext.Tarefas.AddAsync(tarefa);
            await _dbContext.SaveChangesAsync();
            return tarefa;
        }

        public async Task<TarefaModel > AtualizarTarefa(TarefaModel tarefa, int id)
        {
            TarefaModel tarefaPorId = await BuscarPorId(id);

            if(tarefaPorId == null)
            {
                throw new Exception($"Tarefa de id: '{id}' não encontrada no banco de dados!");
            }

            tarefaPorId.Nome = tarefa.Nome;
            tarefaPorId.Descricao = tarefa.Descricao;
            tarefaPorId.Status = tarefa.Status;
            tarefaPorId.UsuarioId = tarefa.UsuarioId;


            _dbContext.Tarefas.Update(tarefaPorId);
            await _dbContext.SaveChangesAsync();

            return tarefaPorId;
        }

        public async Task<bool> ApagarTarefa(int id)
        {
            TarefaModel tarefaPorId = await BuscarPorId(id);

            if (tarefaPorId == null)
            {
                throw new Exception($"Tarefa de id: '{id}' não encontrada no banco de dados!");
            }

            _dbContext.Tarefas.Remove(tarefaPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}

