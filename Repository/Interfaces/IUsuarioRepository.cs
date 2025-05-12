
/*
(Servirá de modelo para outra classe) 
Uma interface especifíca os;
                            nomes e assinaturas de métodos, 
                            propriedades ou eventos, 
mas não implementa o comportamento — isso fica por conta das classes que a implementam.*/

using SistemaTarefas.Models;

namespace SistemaTarefas.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<UsuarioModel>> BuscarTodosUsuarios();
        Task<UsuarioModel> BuscarPorId(int id);
        Task<UsuarioModel> AdicionarUsuario(UsuarioModel usuario);
        Task<UsuarioModel> AtualizarUsuario(UsuarioModel usuario, int id);
        Task<bool> ApagarUsuario(int id);
    }
}
