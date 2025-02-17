# Order Manager

Este é um sistema de gerenciamento de pedidos, desenvolvido com C#/.NET e PostgreSQL. O objetivo principal do projeto é permitir o cadastro, consulta e visualização de pedidos realizados por clientes, com a possibilidade de filtrar pedidos por nome do cliente e data do pedido.

## Funcionalidades

- **Cadastro de Pedidos:** Permite o cadastro de novos pedidos com informações sobre o cliente e os itens do pedido
- **Consulta de Pedidos:** Permite consultar pedidos filtrando por nome do cliente, data de início e data de término
- **Exibição do Total da Venda:** Exibe o valor total de cada pedido, considerando a quantidade de itens e seus preços
- **Validação de Data:** Verifica que os pedidos não podem ser alterados após 24 horas

## Pré-requisitos

- **.NET 6 ou superior:** Certifique-se de que o .NET 6 ou uma versão mais recente está instalado
- **PostgreSQL:** Instale o PostgreSQL e configure o banco de dados
- **Visual Studio ou Visual Studio Code:** IDE recomendada para trabalhar com o projeto

## Instruções para rodar localmente

### 1. Clonando o repositório

Clone o repositório em sua máquina local:

```bash
git clone https://github.com/SEU_USUARIO/SEU_REPOSITORIO.git
```

### 2. Configuração do banco de dados

#### Instalando o PostgreSQL

Se você ainda não tem o PostgreSQL instalado, baixe e instale a partir do site oficial do PostgreSQL.

#### Criando o banco de dados

Depois de instalar o PostgreSQL, crie um banco de dados no seu servidor local. Para isso, abra o terminal do PostgreSQL (psql) e execute:

```sql
CREATE DATABASE order_manager;
```

#### Configurando a string de conexão

No arquivo `appsettings.json`, altere a string de conexão para refletir as credenciais do seu banco de dados PostgreSQL:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Username=<seu_usuario>;Password=<sua_senha>;Database=order_manager;"
  }
}
```

### 3. Executando as migrações

Abra o terminal ou o Package Manager Console no Visual Studio e execute:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 4. Rodando a aplicação

Execute o seguinte comando para iniciar o servidor:

```bash
dotnet run
```

A aplicação estará disponível em `http://localhost:5071`.

### 5. Testando a funcionalidade

- **Cadastro de pedidos:** Ao acessar a página inicial, você pode adicionar novos pedidos
- **Consulta de pedidos:** Filtre os pedidos por nome do cliente e intervalo de datas
- **Exibição do total da venda:** Cada pedido exibirá o valor total calculado

### 6. Exemplo de URL para consultar pedidos com filtro

```bash
http://localhost:5000/orders?clientName=John&startDate=2025-01-01&endDate=2025-02-01
```

## Estrutura do Projeto

- **Controllers:** Contém os controladores da aplicação
- **Data:** Contém o contexto do banco de dados
- **Models:** Contém as classes que representam as entidades da aplicação
- **Views:** Contém as páginas da aplicação

## Contribuições

Contribuições são bem-vindas! Para contribuir com o projeto:

1. Fork o repositório
2. Crie uma branch para sua feature (`git checkout -b minha-nova-feature`)
3. Commit suas alterações (`git commit -am 'Adiciona nova feature'`)
4. Push para a branch (`git push origin minha-nova-feature`)
5. Abra um Pull Request

## Licença

Este projeto está sob a licença MIT - veja o arquivo LICENSE para mais detalhes.

## Considerações Finais

Este projeto foi desenvolvido para aprender mais sobre o desenvolvimento de aplicações web usando C#/.NET, Entity Framework e PostgreSQL. Agradecemos pelo interesse e esperamos que este projeto seja útil para você!
