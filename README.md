# ChallengeNetAPI

Integantes: Ana Paula Nascimento Silva-552513 - Calina Thalya Santana da Silva-552523 - Nathan Nunes Calsonari-552539 - Leonardo Camargo Lucena-552537 - Geovana Ribeiro Domingos Silva-99646

Bem-vindo ao repositório da ChallengeNetAPI! Este projeto é uma API desenvolvida em ASP.NET Core Web API para a empresa Plusoft, utilizando princípios de arquitetura de software, design patterns, técnicas de documentação, testes e integração com banco de dados.

## Arquitetura

### Arquitetura Escolhida: Monolítica

Optamos por uma arquitetura monolítica para este projeto, pois permite uma implementação mais direta e simplificada para o tamanho e escopo atuais. Com uma arquitetura monolítica, todos os componentes da aplicação (Controllers, Services, Repositories, etc.) estão em um único projeto, o que facilita a integração e a comunicação entre eles.

**Justificativa:**

- **Simplicidade:** Para o projeto atual, a arquitetura monolítica oferece uma abordagem mais simples e direta, com todos os componentes no mesmo espaço de nomes.
- **Desenvolvimento e Manutenção:** Facilita o desenvolvimento e a manutenção do código com menos sobrecarga, especialmente quando o projeto não é grande o suficiente para justificar uma abordagem de microservices.
- **Custo e Tempo:** Menor custo de configuração e tempo de desenvolvimento inicial.

Se o projeto crescer ou se houver a necessidade de escalabilidade e desenvolvimento independente de componentes, considerar a migração para uma arquitetura de microservices pode ser uma opção futura.

## Implementação

A API é implementada utilizando ASP.NET Core Web API, seguindo a arquitetura monolítica. A estrutura do projeto é a seguinte:

- **Controllers:** Implementa os endpoints da API para interagir com os recursos (Produtos, Recomendações, Usuários).
- **Services:** Contém a lógica de negócios e coordena a interação entre o Controller e o Repository.
- **Repositories:** Realiza operações de CRUD com o banco de dados.
- **Models:** Define as entidades e DTOs utilizadas na API.
- **Data:** Configuração do banco de dados e implementação dos Repositories.
- **Utils:** Contém utilitários e extensões úteis para a aplicação.

## Endpoints CRUD

### Produtos

- **GET /api/products** - Retorna todos os produtos.
- **GET /api/products/{id}** - Retorna um produto pelo ID.
- **POST /api/products** - Adiciona um novo produto.
- **PUT /api/products/{id}** - Atualiza um produto existente.
- **DELETE /api/products/{id}** - Remove um produto pelo ID.

### Recomendações

- **GET /api/recommendations** - Retorna todas as recomendações.
- **GET /api/recommendations/{id}** - Retorna uma recomendação pelo ID.
- **POST /api/recommendations** - Adiciona uma nova recomendação.
- **PUT /api/recommendations/{id}** - Atualiza uma recomendação existente.
- **DELETE /api/recommendations/{id}** - Remove uma recomendação pelo ID.

### Usuários

- **GET /api/users** - Retorna todos os usuários.
- **GET /api/users/{id}** - Retorna um usuário pelo ID.
- **POST /api/users** - Adiciona um novo usuário.
- **PUT /api/users/{id}** - Atualiza um usuário existente.
- **DELETE /api/users/{id}** - Remove um usuário pelo ID.

## Padrão de Criação Utilizado

**Singleton Pattern** - O padrão Singleton foi utilizado para o gerenciador de configurações na aplicação. Isso garante que apenas uma instância do `ConfigManager` seja criada e utilizada em toda a aplicação, o que é eficiente para gerenciar configurações e manter a consistência em toda a aplicação.

```csharp
public class ConfigManager
{
    private static readonly ConfigManager _instance = new ConfigManager();

    private ConfigManager()
    {
        // Load configurations
    }

    public static ConfigManager Instance => _instance;
}
