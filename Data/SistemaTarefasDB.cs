
//             EntityFrameworkCore = ORM -> mapeia tabelas do banco como classes C#.

using Microsoft.EntityFrameworkCore;
using SistemaTarefas.Data.Map;
using SistemaTarefas.Models;

namespace SistemaTarefas.Data
{
    public class SistemaTarefasDB : DbContext
    {
        //Construtor
        public SistemaTarefasDB(DbContextOptions<SistemaTarefasDB> options) : base(options) { 
        }

        //Tabela Usuarios 
        public DbSet<UsuarioModel> Usuarios { get; set; }


        //Tabela Tarefas
        public DbSet<TarefaModel> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
