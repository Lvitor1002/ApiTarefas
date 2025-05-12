using System.ComponentModel;
namespace SistemaTarefas.Enums
{
    public enum Status : int
    {
        [Description("A fazer")]
        Afazer = 1,

        [Description("Em andamento")]
        EmAndamento = 2,

        [Description("Concluído")]
        Concluido = 3
    }
}
