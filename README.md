# Vitta – Prevenção Personalizada

![Tecnologias](https://img.shields.io/badge/.NET_8-512BD4?style=for-the-badge&logo=dotnet)
![Tecnologias](https://img.shields.io/badge/Oracle-F80000?style=for-the-badge&logo=oracle&logoColor=white)
![Tecnologias](https://img.shields.io/badge/Clean_Architecture-lightgrey?style=for-the-badge)
![Tecnologias](https://img.shields.io/badge/FIAP-ED145B?style=for-the-badge)


### Descrição do Projeto
O **Vitta – Prevenção Personalizada** é uma plataforma digital criada para ajudar as pessoas a cuidarem da saúde de forma simples e motivadora. Ela monitora hábitos como **alimentação, sono e exercícios**, oferecendo **orientações personalizadas** conforme o estilo de vida de cada usuário.  

Mais do que um aplicativo de monitoramento, o Vitta atua como um **assistente de saúde preventiva**, reunindo informações sobre **nutrição, atividade física e bem-estar**, além de **dicas, alertas e metas**.  

Seu propósito é **estimular hábitos saudáveis e prevenir problemas**, tornando o cuidado com a saúde **mais acessível, equilibrado e constante**.


---

### Problema
Hoje, a correria da vida moderna faz com que muitas pessoas deixem a **saúde em segundo plano**. 
Com a rotina cheia, é fácil **perder o controle da alimentação, dormir mal e deixar de se exercitar**.  
Com o tempo, esses hábitos aumentam os riscos de doenças como **diabetes, obesidade e hipertensão**, que poderiam ser evitadas com simples ações diárias.

Apesar de existirem muitos aplicativos de saúde, a maioria **apenas coleta dados** — como passos, calorias ou horas de sono — sem realmente **interpretá-los ou orientar o usuário**.  
Além disso, acompanhar tudo separadamente — **dieta, treino, clima, sono** — pode ser confuso e desmotivador.

O **Vitta** surge para **resolver esse problema**, transformando **dados em cuidados reais**.

---

### Solução Proposta
Criar uma plataforma web que:
- Permita o **cadastro de usuários e acompanhamento de hábitos de saúde**;
- Reúna no futuro informações sobre **alimentação, exercícios e sono**;
- Ofereça **recomendações personalizadas** baseadas no estilo de vida do usuário;
- Estimule o cuidado preventivo e o bem-estar diário.

---

### Stack Tecnológica

* **Framework:** ASP.NET Core 8 MVC
* **Linguagem:** C#
* **Banco de Dados:** Oracle Database
* **ORM:** Entity Framework Core 8
* **Driver do Banco:** `Oracle.EntityFrameworkCore`
* **Arquitetura:** Clean Architecture (adaptada)
* **Front-end:** Bootstrap 5

---

### Requisitos

#### Requisitos Funcionais
- Permitir o cadastro de usuários
- Exibir os usuários em uma página de listagem.  
- Armazenar e recuperar informações básicas dos usuários.  

#### Requisitos Não Funcionais
- Aplicação desenvolvida em ASP.NET Webpages.  
- Código versionado no GitHub com histórico de commits.  
- Interface simples, funcional e responsiva.  
- Preparada para futura integração com APIs e banco Oracle.

---

### Desenho da Arquitetura (Clean Architecture)

* **Domínio (Vitta/Models):** Contém as entidades (`Usuario.cs`) e as interfaces (`IUsuarioRepository.cs`).
* **Aplicação (Vitta/Services):** Contém os casos de uso e regras de negócio (`UsuarioService.cs`).
* **Infraestrutura (Vitta/Data, Vitta/Models/UsuarioRepository.cs):** Implementação do acesso a dados (`VittaDbContext.cs`, `UsuarioRepository.cs`).
* **Apresentação (Vitta/Controllers, Vitta/Views, Vitta/ViewModels):** Camada MVC com rotas customizadas e validações.

---

### Integrantes do Grupo
| Nome | RM |
|------|-------------------|
| Jhonatta Lima Sandes de Oliveira | RM560277 |
| Luann Noqueli Klochko | RM560313 | 
| Lucas Higuti Fontanezi | RM561120 |

---

### Funcionalidades Implementadas

* **CRUD Completo:** Listagem, Criação, Edição e Exclusão de Usuários.
* **Arquitetura Limpa:** Separação clara das camadas:
    * **Domínio:** Entidades (`Usuario.cs`) e Interfaces (`IUsuarioRepository.cs`).
    * **Aplicação:** Serviços e regras de negócio (`UsuarioService.cs`).
    * **Infraestrutura:** Acesso a dados com EF Core (`VittaDbContext.cs`, `UsuarioRepository.cs`).
    * **Apresentação:** Controllers, Views e ViewModels (DTOs).
* **Integração com Oracle:** Conexão com banco de dados Oracle via EF Core e driver `Oracle.EntityFrameworkCore`.
* **Validação de Dados:** Uso de Data Annotations nos ViewModels para validar os inputs do usuário.
* **Injeção de Dependência (DI):** Configurada no `Program.cs` para injetar `Services` e `Repositories`.
* **Layout Customizado:** Navegação e rodapé customizados com Bootstrap.
* **Rotas Amigáveis:** Uso de Attribute Routing (ex: `/Usuario/Novo`, `/Usuario/Editar/5`).

---

### Executando o Projeto
1.  **Clone o repositório:**
    ```bash
    git clone https://github.com/tricodelabs3/sprint-abd-dotnet.git
    ```
2. **Navegue até a pasta do projeto:**
    ```bash
    cd Vitta
    ```

2.  **Configure a Connection String:**
    Abra o arquivo `Vitta/appsettings.json` e altere a `OracleConnection` com os dados do seu banco:
    ```json
    "ConnectionStrings": {
      "OracleConnection": "DATA SOURCE=seu_datasource_oracle;USER ID=seu_usuario;PASSWORD=sua_senha;"
    }
    ```

3.  **Aplique as Migrations:**
    Rode o comando abaixo no terminal (na pasta `Vitta`) para criar as tabelas no banco de dados Oracle:
    ```bash
    dotnet ef database update
    ```

4.  **Rode o Projeto:**
    ```bash
    dotnet run
    ```
    A aplicação estará disponível em `http://localhost:5000` (ou similar).

---

© 2025 – Projeto desenvolvido por **TriCodeLabs** para o Challenge FIAP | Oracle
