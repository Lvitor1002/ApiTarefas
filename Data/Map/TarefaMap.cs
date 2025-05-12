using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTarefas.Models;

namespace SistemaTarefas.Data.Map
{
    public class TarefaMap : IEntityTypeConfiguration<TarefaModel>
    {

        //Mapeamente das Entidades=Tabelas do Banco de dados
        public void Configure(EntityTypeBuilder<TarefaModel> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Nome).IsRequired().HasMaxLength(255);
            builder.Property(u => u.Descricao).IsRequired().HasMaxLength(1000);
            builder.Property(u => u.Status).IsRequired();

            builder.Property(u => u.UsuarioId);
            builder.HasOne(u => u.Usuario);
        }
    }
}
