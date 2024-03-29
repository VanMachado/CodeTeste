# ReadMe

Este é um projeto que utiliza uma imagem padrão do MySQL através do Docker para criar um banco de dados. O projeto foi desenvolvido em .NET 6 e possui instruções para baixar as dependências necessárias e configurar o banco de dados.


## Configuração do Banco de Dados

Para baixar a imagem padrão do MySQL, execute o seguinte comando:

`docker pull mysql`



Em seguida, para instanciar o container e vincular a porta do host com a do container, execute:

`docker run -d -p 3306:3306 --name CodeChallenge -e MYSQL_ROOT_PASSWORD=senha mysql:latest`

## Configuração do Projeto

Após clonar o repositório, execute o seguinte comando para baixar as dependências necessárias:

`dotnet restore`



Em seguida, para criar o esquema das tabelas, use o PowerShell de desenvolvedor e execute o seguinte comando (substitua `NomeDaMigration` pelo nome desejado da migration):

`dotnet ef migrations add FirstMigration`



Caso o projeto já tenha a pasta "Migrations", basta prosseguir para o próximo passo.

Para aplicar as mudanças no banco de dados, execute:

`dotnet ef database update`



Antes de iniciar o programa, certifique-se de criar o banco de dados "clients" juntamente com as tabelas. Isso pode ser feito com o comando mencionado anteriormente para evitar o erro 500, pois o "SeedingService" é responsável por fazer a população do banco de dados.


