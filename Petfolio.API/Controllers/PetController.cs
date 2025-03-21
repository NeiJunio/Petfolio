using Microsoft.AspNetCore.Mvc;
using Petfolio.Application.UseCases.Pets.Delete;
using Petfolio.Application.UseCases.Pets.GetAll;
using Petfolio.Application.UseCases.Pets.GetById;
using Petfolio.Application.UseCases.Pets.Register;
using Petfolio.Application.UseCases.Pets.Update;
using Petfolio.Communication.Requests;
using Petfolio.Communication.Responses;

namespace Petfolio.API.Controllers;

[Route("api/[controller]")]
[ApiController]

public class PetController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisterPetJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromBody] RequestPetJson
 request)
    {
        var useCase = new RegisterPetUseCase(); // Cria uma instância direcionada para a classe RegisterPetUseCase

        var response = useCase.Execute(request); // dentro da classe RegisterPetUseCase, acessa a função com nome Execute(), passando para ela o parâmetro request

        return Created(string.Empty, response); // a função Created sempre retorna dois parâmetros, então para evitar conflitos, sempre passar o primeiro parâmetro como strng.Empty
    }


    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    public IActionResult Update([FromRoute] int id, [FromBody] RequestPetJson
 request)
    {
        var useCase = new UpdatePetUseCase();

        useCase.Execute(id, request);
        // dentro da classe UpdatePetUseCase, acessa a função com nome Execute(), passando para ela o parâmetro id e request

        return NoContent();
    }


    [HttpGet]
    [ProducesResponseType(typeof(ResponseAllPetJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetAll()
    {
        var useCase = new GetAllPetsUseCase();

        var response = useCase.Execute(); // dentro da classe ResponseAllPetJson, acessa a função com nome Execute()

        if (response.Pets.Any())
        {
            return Ok(response);
        }

        return NoContent();
    }


    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponsePetJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
    public IActionResult GetById(int id)
    {
        var useCase = new GetPetByIdUseCase();

        var response = useCase.Execute(id); // dentro da classe ResponsePetJson, acessa a função com nome Execute(), passando para ela o parâmetro id

        return Ok(response);
    }

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
}
