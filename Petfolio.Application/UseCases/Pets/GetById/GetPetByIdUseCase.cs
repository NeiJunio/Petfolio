using Petfolio.Communication.Responses;

namespace Petfolio.Application.UseCases.Pets.GetById;

public class GetPetByIdUseCase
{
    public ResponsePetJson Execute(int id)
    {
        return new ResponsePetJson
        {
            Id = id,
            Name = "Luna",
            Type = Communication.Enums.PetType.Dog,
            Birthday = new DateTime(year: 2022, month: 01, day: 01)
        };
    }
}
