<h3>Esta Web API é uma aplicação ASP.NET Core que fornece um Back-End para um sistema de gerenciamento de tarefas<h3>
<br>
<p>
  -Utiliza o Entity Framework Core para acesso ao banco de dados SQL Server, configurando a string de conexão via appsettings.json.
  -Utiliza o Swagger para documentação automática da API durante o desenvolvimento.
  
  <strong>Injeção de Dependências:</strong> Registra os repositórios IUsuarioRepository e ITarefaRepository para controle de usuários e tarefas.
  <strong>Registra integrações externas:</strong> IViaCepIntegration e IViaCepIntegrationRefit para consumo de serviços externos (como a API do ViaCEP para buscar endereços por CEP).
</p>
<br>
<br>
<h1>Swagger UI</h1>

<div>
  <img src="Swagger.png" width="1000px"/>
</div>
