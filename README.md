# GerenciamentoClientesAPI - README

## Descrição
**GerenciamentoClientesAPI** é uma API RESTful em **ASP.NET Core** para gerenciar informações de clientes. 
Permite listar, criar, atualizar e excluir clientes usando **Entity Framework Core** com um banco de dados relacional.

## Funcionalidades
- **Listar Clientes**: Obter uma lista paginada de clientes.
- **Obter Cliente por ID**: Buscar informações de um cliente específico.
- **Criar Cliente**: Adicionar um novo cliente.
- **Atualizar Cliente**: Modificar dados de um cliente existente.
- **Excluir Cliente**: Remover um cliente.
- **Consultar Endereço por CEP**: Utiliza o serviço ViaCEP para buscar informações de endereço a partir de um CEP.

### ViaCEPService
A classe `ViaCEPService` consulta informações de endereço usando o serviço ViaCEP.

## Estrutura do Projeto
- **Controllers**: Exposição dos endpoints da API.
- **Services**: Lógica de negócio.
- **Repositories**: Interação com o banco de dados.
- **Models**: Entidades do sistema (Cliente, Endereço, Telefone, Email).
- **Data**: Configuração do banco de dados.


## Como Executar

### Requisitos
- **.NET 6.0** ou superior
- **SQLite** (substituível por outro banco relacional)

### Passos
1. Clone o repositório:
   ```bash
   git clone https://github.com/Ruan92929/GerenciamentoDeClientesAPI.git
2. Restaure as dependências:
   dotnet restore
3. Configure a string de conexão no appsettings.json:
"ConnectionStrings": {
  "SQLiteConnection": "Data Source=clientes.db"
}
4. Rode as migrações:
dotnet ef database update

5. Execute o projeto
dotnet run
