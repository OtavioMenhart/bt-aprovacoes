# Api.Processos

Aplique a migration no projeto Api.Processos.Data: dotnet ef database update

A conexão do banco de dados está na classe ConfigureRepository e apontando para local: (localdb)\\MSSQLLocalDB

Para executar o front:
- ng build --prod
- docker build -t bt-processos-front .
- docker run -it --rm -p 4200:80 bt-processos-front
