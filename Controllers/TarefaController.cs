

using Microsoft.AspNetCore.Mvc;
using SistemaTarefas.Models;
using SistemaTarefas.Repository.Interfaces;


namespace SistemaTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepository _tarefaRepository;

        //Construtor
        public TarefaController(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }



        // GET: Buscar Tarefas
        [HttpGet]
        public async Task<ActionResult<List<TarefaModel >>> ListarTodasTarefas() 
        {
            List<TarefaModel > listaTarefas = await _tarefaRepository.BuscarTodasTarefas();
            return Ok(listaTarefas);
        }

        // GET: Buscar ÚNICA Tarefas
        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaModel >> BuscarPorId(int id)
        {
            TarefaModel unicaTarefa = await _tarefaRepository.BuscarPorId(id);
            return Ok(unicaTarefa);
        }

        // POST: Enviar dados ao servidor
        [HttpPost]
        public async Task<ActionResult<TarefaModel >> AdicionarTarefa([FromBody] TarefaModel tarefaModel)
        {
            TarefaModel tarefa = await _tarefaRepository.AdicionarTarefa(tarefaModel);
            return Ok(tarefa);
        }


        // PUT: Atualizar dados
        [HttpPut("{id}")]
        public async Task<ActionResult<TarefaModel >> AtualizarTarefa([FromBody] TarefaModel tarefaModel, int id)
        {
            tarefaModel.Id = id;
            TarefaModel tarefa = await _tarefaRepository.AtualizarTarefa(tarefaModel, id);
            return Ok(tarefa);
        }

        // DELETE: Remover dados
        [HttpDelete("{id}")]
        public async Task<ActionResult<TarefaModel>> ApagarTarefa(int id)
        {
            bool apagado = await _tarefaRepository.ApagarTarefa(id);
            return Ok(apagado);
        }

    }
}
