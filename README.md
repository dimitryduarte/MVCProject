# MVCProject

LIBRARIES
-----------------
Foram utilizados para este projeto os seguintes recursos:
- Docker (SQL Server)
- .Net Framework
- Entity Framework
- xUnit
- Moq
- Faker
- AutoBoggus
- Jquery (Ajax)
- SweetAlert

INSTRUÇÕES
---------------------
Para inicializar o projeto, pode ser utilizada uma instância de docker já configurada executando o comando a seguir:
```
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Password#2022" -p 1450:1433 --name sqlserverdb -d mcr.microsoft.com/mssql/server
```

A autenticação desse container já está configurada no projeto.

Após inicializar o projeto, basta executar as migrations com o comando:
```
Update-Database
```
Feito isso o projeto será inicializado com sucesso.
