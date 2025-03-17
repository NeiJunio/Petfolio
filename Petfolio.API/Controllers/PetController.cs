using Microsoft.AspNetCore.Mvc;
using Petfolio.Application.UseCases.Pet.Register;
using Petfolio.Communication.Requests;
using Petfolio.Communication.Responses;

namespace Petfolio.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PetController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisterPetJson), StatusCodes.Status201Created)]
    public IActionResult Register([FromBody] RequestRegisterPetJson request)
    {
        var useCase = new RegisterPetUseCase(); // Cria uma instância direcionada para a classe RegisterPetUseCase
        
        var response = useCase.Execute(request); // dentro da classe RegisterPetUseCase, acessa a função com nome Execute(), passando para ela o parâmetro request

        return Created(string.Empty, response); // a função Created sempre retorna dois parâmetros, então para evitar conflitos, sempre passar o primeiro parâmetro como strng.Empty
    }
}
