# AcademyManager
# 🎓 Sistema de Gerenciamento Acadêmico - API

Esta aplicação é uma **API RESTful** desenvolvida com **.NET 8** para servir como backend de um sistema administrativo. Seu objetivo é permitir que usuários possam gerenciar **alunos**, **turmas** e **matrículas** de forma eficiente e escalável.

## 🛠️ Tecnologias Utilizadas

- .NET 8
- ASP.NET Core
- MediatR
- FluentValidation
- Swagger
- Entity Framework Core
- SQL Server
- xUnit (Testes Unitários)

## 🚀 Como Executar a Aplicação

> ⚠️ Pré-requisitos: .NET 8 SDK instalado, SQL Server disponível

1. Clone o repositório:
   ```bash
   git clone https://github.com/LarissaCGoncalves/AcademyManager.git
   
2. Acesse a pasta do projeto:
   ```bash
   cd AcademyManager

4. Configure a connection string no appsettings.json da camada de API:
    ```bash
   "ConnectionStrings": { "DefaultConnection": "Server=SEU_SERVIDOR;Database=AcademyDB;Trusted_Connection=True;" }

6. Execute a aplicação a partir da pasta AcademyManager.Api:
    ```bash
    dotnet run

7. **Abra o navegador** e acesse o Swagger para explorar e testar os endpoints disponíveis da API.  
   Basta acessar a porta em que a aplicação está rodando localmente, seguida de `/swagger/index.html`, por exemplo:
    ```bash
    http://localhost:5051/swagger/index.html

> 📌 Obs.: A porta pode variar de acordo com o ambiente. Verifique o terminal após executar `dotnet run` — ele indicará o endereço exato onde a API está escutando.

## 📂 Estrutura do Projeto
O projeto segue os princípios do DDD, com Clean Architecture e CQRS, visando escalabilidade e manutenibilidade. A estrutura está dividida em:

* Api: Camada de apresentação onde estão as controllers e middlewares

* Application: Contém os commands, handlers e queries

* Domain: Agrupa as entidades, value objects e interfaces de repositórios

* Infra: Configuração do Entity Framework, mapeamentos e implementação de repositórios

* Shared: Abstrações e utilitários compartilhados entre as camadas

* Tests: Projeto de testes unitários com xUnit

## ⚙️ Configuração
As configurações de ambiente, como a string de conexão com o banco de dados, devem ser definidas no arquivo appsettings.json, localizado na camada API. Ajuste conforme descrito no item 3 da seção 'Como executar a aplicação'.

## ✅ Testes
Os testes unitários estão no projeto Tests e utilizam o framework xUnit. Para executá-los, basta executar o comando na pasta AcademyManager.Tests:
```bash
dotnet test


