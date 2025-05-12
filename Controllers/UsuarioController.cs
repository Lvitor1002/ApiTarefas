

using Microsoft.AspNetCore.Mvc;
using SistemaTarefas.Models;
using SistemaTarefas.Repository.Interfaces;


namespace SistemaTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        //Construtor
        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }



        // GET: Buscar usuários
        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarTodosUsuarios() 
        {
            List<UsuarioModel> listaUsuarios = await _usuarioRepository.BuscarTodosUsuarios();
            return Ok(listaUsuarios);
        }

        // GET: Buscar ÚNICO usuários
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> BuscarPorId(int id)
        {
            UsuarioModel unicoUsuario = await _usuarioRepository.BuscarPorId(id);
            return Ok(unicoUsuario);
        }

        // POST: Enviar dados ao servidor
        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> AdicionarUsuario([FromBody] UsuarioModel usuarioModel)
        {
            UsuarioModel usuario = await _usuarioRepository.AdicionarUsuario(usuarioModel);
            return Ok(usuario);
        }


        // PUT: Atualizar dados
        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> AtualizarUsuario([FromBody] UsuarioModel usuarioModel, int id)
        {
            usuarioModel.Id = id;
            UsuarioModel usuario = await _usuarioRepository.AtualizarUsuario(usuarioModel,id);
            return Ok(usuario);
        }

        // DELETE: Apagar dados
        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> ApagarUsuario(int id)
        {
            bool apagado = await _usuarioRepository.ApagarUsuario(id);
            return Ok(apagado);
        }

    }
}
