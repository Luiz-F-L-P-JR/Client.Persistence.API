# Client Persistence API

Esta é uma API RESTful criada com .NET 8, utilizando uma arquitetura baseada em Domain-Driven Design (DDD) e o padrão Domain Model Design. A API gerencia clientes e seus respectivos logradouros, com endpoints autenticados e autorizados através de JWT. Ela utiliza Dapper e stored procedures, seguindo o padrão Repository Pattern.

## Instalação e Execução

Siga estas etapas para configurar e executar a API localmente:

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
- [Git](https://git-scm.com/)
- Um banco de dados SQL Server

### Clonando o repositório

```bash
git clone https://github.com/Luiz-F-L-P-JR/Client.Persistence.API.git
```

### Configuração

1. Navegue até o diretório do projeto:

```bash
cd Client.Persistence.API
```

2. Abra o arquivo `appsettings.json` e atualize as configurações conforme necessário, especialmente as configurações relacionadas ao JWT para autenticação e autorização, e as configurações do banco de dados para conexão com o SQL Server.

### Executando o projeto

1. Abra um terminal na pasta raiz do projeto e execute o comando:

```bash
dotnet run
```

2. O projeto estará acessível nas rotas indicadas no arquivo launchSettings.json utilize http://localhost: e a número da porta.

## Contribuindo

Sinta-se à vontade para contribuir com melhorias, correções de bugs ou novos recursos. Basta seguir estas etapas:

1. Faça um fork do repositório.
2. Crie uma nova branch com a sua feature (`git checkout -b feature/nova-feature`).
3. Faça commit das suas alterações (`git commit -am 'Adiciona nova feature'`).
4. Faça push para a branch (`git push origin feature/nova-feature`).
5. Crie um novo Pull Request.

## Contato

Para mais informações, entrem em contato com Luizfernandojr1998@gmail.com.

---
