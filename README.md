# Order Manager

## Este é um sistema de gerenciamento de pedidos, desenvolvido com C#/.NET e PostgreSQL. O objetivo principal do projeto é permitir o cadastro, consulta e visualização de pedidos realizados por clientes, com a possibilidade de filtrar pedidos por nome do cliente e data do pedido.

## Funcionalidades

- **Cadastro de Pedidos:** Permite o cadastro de novos pedidos com informações sobre o cliente e os itens do pedido.
- **Consulta de Pedidos:** Permite consultar pedidos filtrando por nome do cliente, data de início e data de término.
- **Exibição do Total da Venda:** Exibe o valor total de cada pedido, considerando a quantidade de itens e seus preços.
- **Validação de Data:** Verifica que os pedidos não podem ser alterados após 24 horas.

## Pré-requisitos

- **.NET 6 ou superior**: Certifique-se de que o .NET 6 ou uma versão mais recente está instalado.
- **PostgreSQL**: Instale o PostgreSQL e configure o banco de dados.
- **Visual Studio ou Visual Studio Code**: IDE recomendada para trabalhar com o projeto.

## Instruções para rodar localmente

### 1. Clonando o repositório

## Clone o repositório em sua máquina local:

```
    git clone https://github.com/SEU_USUARIO/SEU_REPOSITORIO.git
```

### 2. Configuração do banco de dados
## Instalando o PostgreSQL: Se você ainda não tem o PostgreSQL instalado, baixe e instale a partir do site oficial do PostgreSQL.

## Criando o banco de dados:

## Depois de instalar o PostgreSQL, crie um banco de dados no seu servidor local. Para isso, abra o terminal do PostgreSQL (psql) e execute:

## CREATE DATABASE order_manager;

## Configurando a string de conexão:

## Após criar o banco de dados, configure a string de conexão no seu projeto para apontar para o banco de dados recém-criado.

## No arquivo appsettings.json, altere a string de conexão para refletir as credenciais do seu banco de dados PostgreSQL. Substitua <seu_usuario>, <sua_senha> e <seu_banco> pelos valores adequados:
```
    {
        "ConnectionStrings": {
            "DefaultConnection": "Host=localhost;Port=5432;Username=<seu_usuario>;Password=<sua_senha>;Database=order_manager;"
        }
    }
```

### 3. Executando as migrações
## O próximo passo é configurar o banco de dados para a aplicação. Use o Entity Framework para gerar as tabelas necessárias.

## Abra o terminal ou o Package Manager Console no Visual Studio.

## Execute o comando a seguir para gerar as migrações iniciais:

## dotnet ef migrations add InitialCreate

## Isso criará um arquivo de migração para criar as tabelas no banco de dados.

## Após criar a migração, aplique-a ao banco de dados com o comando:

## dotnet ef database update

## Este comando criará todas as tabelas necessárias no banco de dados PostgreSQL de acordo com os modelos do seu projeto.


### 4. Rodando a aplicação
## Agora que o banco de dados foi configurado, você pode rodar a aplicação localmente.

## Abra o terminal na pasta do seu projeto e execute o seguinte comando para iniciar o servidor:

```
    dotnet run
```
## A aplicação estará disponível em http://localhost:5071.

### 5. Testando a funcionalidade
## Cadastro de pedidos: Ao acessar a página inicial, você pode adicionar novos pedidos, associando-os a um cliente existente ou criando um novo cliente.

## Consulta de pedidos: Você pode filtrar os pedidos por nome do cliente, data de início e data de término. A consulta retornará uma lista de pedidos que atendem aos critérios especificados.

## Exibição do total da venda: Cada pedido exibirá o valor total calculado a partir dos itens associados.
### 6. Exemplo de URL para consultar pedidos com filtro
## Para consultar pedidos feitos entre duas datas, você pode acessar uma URL similar a:

```
    http://localhost:5000/orders?clientName=John&startDate=2025-01-01&endDate=2025-02-01
```

## Isso filtrará os pedidos realizados por um cliente chamado "John" entre 1 de janeiro de 2025 e 1 de fevereiro de 2025.

## Estrutura do Projeto

## Controllers: Contém os controladores da aplicação, como o OrderController que gerencia as requisições relacionadas aos pedidos.

## Data: Contém o contexto do banco de dados (ApplicationDbContext) e a configuração para conectar-se ao PostgreSQL.

## Models: Contém as classes que representam as entidades da aplicação, como Order, Client, e ItemOrder.

## Views: Contém as páginas da aplicação que são renderizadas no front-end. Utiliza Razor para renderizar os dados dinâmicos.

## Contribuições

## Contribuições são bem-vindas! Para contribuir com o projeto:

## Fork o repositório.

## Crie uma branch para sua feature (git checkout -b minha-nova-feature).
## Commit suas alterações (git commit -am 'Adiciona nova feature').
## Push para a branch (git push origin minha-nova-feature).
## Abra um Pull Request.
## Licença
## Este projeto está sob a licença MIT - veja o arquivo LICENSE para mais detalhes.

## Considerações Finais
## Este projeto foi desenvolvido para aprender mais sobre o desenvolvimento de aplicações web usando C#/.NET, Entity Framework e PostgreSQL. Agradecemos pelo interesse e esperamos que este projeto seja útil para você!


### Explicação:

- O `README.md` fornece instruções detalhadas para rodar o projeto localmente, desde a configuração do banco de dados PostgreSQL até a execução da aplicação.
- Contém etapas claras de como criar o banco, configurar a string de conexão, rodar as migrações com o Entity Framework e executar o servidor.
- Além disso, o arquivo explica as funcionalidades do projeto e como testar o sistema localmente, fornecendo exemplos de uso.

## Isso deve cobrir todas as etapas necessárias para configurar e rodar o seu projeto localmente.
