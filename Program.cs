
using Microsoft.EntityFrameworkCore;
using SistemaTarefas.Data;
using SistemaTarefas.Repository.Interfaces;
using SistemaTarefas.Repository;

using SistemaTarefas.Integration.Refit;
using Refit;
using SistemaTarefas.Integration.Interfaces;
using SistemaTarefas.Integration;

namespace SistemaTarefas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();



            //--------------------------------------------------------------------------------------------
            // Configura��o de conex�o com o banco
            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<SistemaTarefasDB>(
                    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            
            //Inje��o de depend�ncia para Usuarios
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            //Inje��o de depend�ncia para Tarefas
            builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();

            //Inje��o de depend�ncia para integra��o da API
            builder.Services.AddScoped<IViaCepIntegration, ViaCepIntegration>();

            builder.Services.AddRefitClient<IViaCepIntegrationRefit>().ConfigureHttpClient(c =>{
                c.BaseAddress = new Uri("https://viacep.com.br");
            });
            //--------------------------------------------------------------------------------------------



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
