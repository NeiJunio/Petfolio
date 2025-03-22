# PETFOLIO API

## Descrição

<p align="justify">O <strong>Petfolio</strong> é uma aplicação desenvolvida em <strong>.NET</strong> para gerenciamento de pets, permitindo o cadastro, atualização, consulta e remoção de registros de animais. O projeto é estruturado em uma <strong>API RESTful</strong>, utilizando <strong>ASP.NET Core Web API</strong> para a camada de serviços, uma biblioteca de comunicação para padronizar <strong>Requests e Responses</strong>, e uma camada de aplicação responsável pela lógica de negócio. A arquitetura modular facilita a manutenção e escalabilidade, garantindo um código organizado e eficiente.</p> 


## Resumo da Estrutura de Diretórios do Projeto Petfolio

<p align="justify">O projeto Petfolio é estruturado em camadas, promovendo uma arquitetura modular e separação de responsabilidades:</p>

- **`Petfolio.API/`**: Camada responsável pela exposição da API, com controladores e configuração de endpoints.
- **`Petfolio.Application/`**: Contém a lógica de negócios e os casos de uso (CRUD) relacionados aos pets.
- **`Petfolio.Communication/`**: Define os objetos de comunicação, como requisições e respostas da API.

<p align="justify">Cada camada possui arquivos de configuração e dependências específicas, além de diretórios para binários e objetos gerados automaticamente. A estrutura facilita a escalabilidade e manutenção do sistema.</p>


<details>
  <summary>Ver Estrutura</summary>

  ```csharp
  Directory structure:
└── neijunio-petfolio/
    ├── Petfolio.sln
    ├── Petfolio.API/
    │   ├── appsettings.Development.json
    │   ├── appsettings.json
    │   ├── Petfolio.API.csproj
    │   ├── Petfolio.API.http
    │   ├── Program.cs
    │   ├── bin/
    │   ├── Controllers/
    │   │   └── PetController.cs
    │   ├── obj/
    │   └── Properties/
    │       └── launchSettings.json
    ├── Petfolio.Application/
    │   ├── Petfolio.Application.csproj
    │   ├── bin/
    │   ├── obj/
    │   └── UseCases/
    │       └── Pets/
    │           ├── Delete/
    │           │   └── DeletePetByIdUseCase.cs
    │           ├── GetAll/
    │           │   └── GetAllPetsUseCase.cs
    │           ├── GetById/
    │           │   └── GetPetByIdUseCase.cs
    │           ├── Register/
    │           │   └── RegisterPetUseCase.cs
    │           └── Update/
    │               └── UpdatePetUseCase.cs
    └── Petfolio.Communication/
        ├── Petfolio.Communication.csproj
        ├── bin/
        ├── Enums/
        │   └── PetType.cs
        ├── obj/
        ├── Requests/
        │   └── RequestPetJson.cs
        └── Responses/
            ├── ResponseAllPetJson.cs
            ├── ResponseErrorsJson.cs
            ├── ResponsePetJson.cs
            ├── ResponseRegisterPetJson.cs
            └── ResponseShortPetJson.cs

  ```

</details>


## Passo a passo de elaboração
<p align="justify">A seguir, será detalhado o processo de elaboração do projeto Petfolio, com uma explicação de cada etapa de sua construção.</p>

<details>
  <summary>1. Estrutura Inicial do Projeto</summary>
  
  ### Criação de uma solução:
  - Abra o Visual Studio e crie uma nova solução vazia:
  - File > New > Project > Blank Solution
  - Nomeie a solução como Petfolio.
  
  ### Adição dos projetos:
  - **Projeto API (Web API):**
    - Botão direito na solução Petfolio > Add > New Project > ASP.NET Core Web API.
    - Nomeie o projeto como Petfolio.API.
  - **Projeto Communication (para Requests e Responses):**
    - Botão direito na solução Petfolio > Add > New Project > Class Library.
    - Nomeie o projeto como Petfolio.Communication.
  - **Projeto Application (para a regra de negócios):**
    - Botão direito na solução Petfolio > Add > New Project > Class Library.
    - Nomeie o projeto como Petfolio.Application.
  </details>

<details>
  <summary>2. Configuração dos Projetos</summary>
  
  ### Definir o projeto API como startup:
  - Botão direito no projeto Petfolio.API > Set as Startup Project.
  
  ### Referências entre os projetos:
  - **Petfolio.API:**
    - Adicione referência para Petfolio.Communication e Petfolio.Application.
  - **Petfolio.Application:**
    - Adicione referência para Petfolio.Communication.
  - **Petfolio.Communication:**
    - Não precisa referenciar nenhum outro projeto.
  
  ### Criar o PetController:
  - Na pasta Controllers do Petfolio.API, crie o arquivo `PetController.cs`.
  - 
</details>

<details>
  <summary>3. Estrutura do Projeto Communication</summary>
  
  ### Criar as pastas Requests, Responses e Enums
  
  #### Estrutura e arquivos da pasta Request:
  - Crie uma pasta chamada <strong><i>Requests</i></strong>
    - Criar a classe `RequestPetJson.cs`:
   
      ```csharp
      public class RequestPetJson
      {
          public string Name { get; set; } = string.Empty; // Nome nunca vai  ser    nulo, no máximo uma string vazia
          public DateTime Birthday { get; set; }
          public PetType Type { get; set; }
      }
      ```

  #### Estrutura e arquivos da pasta Request:
  - Crie uma pasta chamada <strong><i>Responses</i></strong>
    - Criar a classe `ResponseRegisterPetJson`:
      
      ```csharp
      public class ResponseRegisterPetJson
      {
          public int Id { get; set; }
          public string Name { get; set; } = string.Empty;
      }
      ```
  
    - Criar a classe `ResponseAllPetJson`:
      
      ```csharp
      public class ResponseAllPetJson
      {
          public List<ResponseShortPetJson> Pets { get; set; } = [];
      }
      ```
  
    - Criar a classe `ResponseShortPetJson`:
      - Essa classe listará apenas as informações resumidades que deverão ser   mostradas
    
      ```csharp
      public class ResponseShortPetJson
      {
          public int Id { get; set; }
          public string Name { get; set; } = string.Empty;
          public PetType Type { get; set; }
      }
      ```
  
    - Criar a classe `ResponsePetJson`:
      
      ```csharp
      public class ResponsePetJson
      {
          public int Id { get; set; }
          public string Name { get; set; } = string.Empty; // Nome nunca vaser nulo,   no máximo uma string vazia
          public DateTime Birthday { get; set; }
          public PetType Type { get; set; }
      }
      ```
  
    - Criar a classe `ResponseErrorsJson`:
  
      ```csharp
      public class ResponseErrorsJson
      {
          public List<string> Errors { get; set; } = []; 
          // cria a lista vazia, mas não nula
          // Quando a gente instanciar a classe ResponseErrorsJson, o Errors já   receberá uma instância vazia, ficando assim, pronto para receber os   erros        
      }
      ```

  #### Estrutura e arquivos da pasta Enums:
  - Crie uma pasta chamada <strong><i>Enums</i></strong>
    - Criar a classe `PetType.cs`:
      
      ```csharp
      public enum PetType
      {
          Cat = 0,
          Dog = 1,
          Bird = 2
      }
      ```

</details>

<details>
  <summary>4. Regras de Negócio no Petfolio.Application</summary>

  ### Criar a pasta UseCase

  #### Estrutura e arquivos da pasta UseCase:
  - Crie uma pasta chamada <strong><i>Pets</i></strong>
    
    <br>
  - <strong><i>Dentro da pasta Pets: </i></strong>
  
  - Crie uma pasta chamada <strong><i>Delete</i></strong>
    - Criar a classe `DeletePetByIdUseCase.cs`:
  
      ```csharp
      public class DeletePetByIdUseCase
      {
          public void Execute(int id){
              // Regra de negócios
          }
      }
      ```

  - Crie uma pasta chamada <strong><i>GetAll</i></strong>
    - Criar a classe `GetAllPetsUseCase.cs`:
  
      ```csharp
      public class GetAllPetsUseCase
      {
          public ResponseAllPetJson Execute()
          {
              return new ResponseAllPetJson
              {
                  Pets = new List<ResponseShortPetJson>
                  {
                      new ResponseShortPetJson {
                          Id = 1,
                          Name = "Max",
                          Type = Communication.Enums.PetType.Dog
                      },
                  }
              };
          }
      }
      ```
 
  - Crie uma pasta chamada <strong><i>GetById</i></strong>
    - Criar a classe `GetPetByIdUseCase.cs`:
    
      ```csharp
      public class GetPetByIdUseCase
      {
          public ResponsePetJson Execute(int id){
              return new ResponsePetJson{
                  Id = id,
                  Name = "Luna",
                  Type = Communication.Enums.PetType.Dog,
                  Birthday = new DateTime(year: 2022, month: 01, day: 01)
              };
          }
      }
      ```
    
  - Crie uma pasta chamada <strong><i>Register</i></strong>
    - Criar a classe `RegisterPetUseCase.cs`:
    
      ```csharp
      public class RegisterPetUseCase
      {
          public ResponseRegisterPetJson Execute(RequestPetJson request)
          {
              return new ResponseRegisterPetJson
              {
                  Id = 1,
                  Name = request.Name,
              };
          }
      }
      ```

  - Crie uma pasta chamada <strong><i>Update</i></strong>
    - Criar a classe `UpdatePetUseCase.cs`:
    
      ```csharp
      public class UpdatePetUseCase
      {
          public void Execute(int id, RequestPetJson request)
          {
            // Lógica de atualização fictícia
          }
      }
      ```
</details>

<details>
  <summary>5. Controller - Criação dos Endpoints</summary>

  #### Endpoint POST - Criar um Pet
  - Dentro de PetController, crie o endpoint POST para cadastrar um novo pet.
  - Deverá ser passado os seguintes ProducesType: 
    - ProducesType com typeof referenciando a classe ResponseRegisterPetJson, e um status 201 de Created
    - ProducesType com typeof referenciando a classe ResponseErrorsJson, e um status 400 de BadRequest
  
      ```csharp
      [HttpPost]
      [ProducesResponseType(typeof(ResponseRegisterPetJson), StatusCodes.Status201Created)]
      [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
      public IActionResult Register([FromBody] RequestPetJson request)
      {
          var useCase = new RegisterPetUseCase(); // Cria uma instância direcionada   para a classe RegisterPetUseCase
  
          var response = useCase.Execute(request); // dentro da classe   RegisterPetUseCase, acessa a função com nome Execute(), passando para ela   o parâmetro request
  
          return Created(string.Empty, response); // a função Created sempre retorna   dois parâmetros, então para evitar conflitos, sempre passar o primeiro   parâmetro como strng.Empty
      }
      ```
  <br>

  #### Endpoint PUT - Atualizar Pet
  - No PetController, crie o endpoint PUT para editar um pet.
  - Obrigatório o uso do Route para inserir o id na rota
  - Como parâmetros da função devemos passar o id pelo FromRoute, e a RequestPetJson, que contém todos os campos esperados, pelo FromBody
  - Deverá ser passado os seguintes ProducesType:
    - status 204 de NoContent, para uma requisição que deu sucesso mas não retorna dados
    - ProducesType com typeof referenciando a classe ResponseErrorsJson, e um status 400 de BadRequest

      ```csharp
      [HttpPut]
      [Route("{id}")]
      [ProducesResponseType(StatusCodes.Status204NoContent)]
      [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
      public IActionResult Update([FromRoute] int id, [FromBody] RequestPetJson request)
      {
          var useCase = new UpdatePetUseCase();

          useCase.Execute(id, request);
          // dentro da classe UpdatePetUseCase, acessa a função com nome Execut(),    passando para ela o parâmetro id e request

          return NoContent();
      }
      ```

  <br>

  #### Endpoint GET - Buscar Todos os Pets
  - Crie um endpoint GET para listar todos os pets.
  - Deverá ser passado os seguintes ProducesType:
    - ProducesType com typeof referenciando a classe ResponseAllPetJson, e um status 200 (OK)
    - status 204 de NoContent, para uma requisição que deu sucesso mas não retorna dados
  
      ```csharp
      [HttpGet]
      [ProducesResponseType(typeof(ResponseAllPetJson), StatusCodes.Status200OK)]
      [ProducesResponseType(StatusCodes.Status204NoContent)]
      public IActionResult GetAll()
      {
          var useCase = new GetAllPetsUseCase();
  
          var response = useCase.Execute(); // dentro da classe ResponseAllPetJson,   acessa a função com nome Execute()
  
          if (response.Pets.Any())
          {
              return Ok(response);
          }
  
          return NoContent();
      }
      ```

  <br>

  #### Endpoint GET - Buscar Pet por ID
  - Crie o endpoint GET para buscar um pet específico por ID.
  - Deverá ser passado os seguintes ProducesType:
    - ProducesType com typeof referenciando a classe ResponsePetJson, e um status 200 (OK)
    - ProducesType com typeof referenciando a classe ResponseErrorsJson, e status 404 de NotFound
  
      ```csharp
      [HttpGet]
      [Route("{id}")]
      [ProducesResponseType(typeof(ResponsePetJson), StatusCodes.Status200OK)]
      [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
      public IActionResult GetById(int id)
      {
          var useCase = new GetPetByIdUseCase();
  
          var response = useCase.Execute(id); // dentro da classe ResponsePetJson,   acessa a função com nome Execute(), passando para ela o parâmetro id
  
          return Ok(response);
      }
      ```

  <br>

  #### Endpoint DELETE - Deletar Pet
  - Crie o endpoint DELETE para remover um pet.
  - Deverá ser passado os seguintes ProducesType:
    - status 204 (NoContent), para quand a requisição da sucesso mas não retorna dados
    - ProducesType com typeof referenciando a classe ResponseErrorsJson, e status 404 de NotFound

      ```csharp
      [HttpDelete]
      [Route("{id}")]
      [ProducesResponseType(StatusCodes.Status204NoContent)]
      [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
      public IActionResult Delete(int id)
      {
        var useCase = new DeletePetByIdUseCase();

        useCase.Execute(id);

        return NoContent();
      }
      ```    
</details>
<br>

## Endpoints da API

A API possui os seguintes endpoints para gerenciamento de pets:

- #### 1. Criar um Pet
  - **Rota:** `POST api/Pet`

- #### 2. Atualizar um Pet
  - **Rota:** `PUT api/Pet/{id}`

- #### 3. Buscar Todos os Pets
  - **Rota:** `GET api/Pet`

- #### 4. Buscar Pet por ID
  - **Rota:** `GET api/Pet/{id}`

- #### 5. Deletar um Pet
  - **Rota:** `DELETE api/Pet/{id}`


