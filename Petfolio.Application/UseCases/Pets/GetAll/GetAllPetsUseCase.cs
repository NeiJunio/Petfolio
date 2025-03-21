using Petfolio.Communication.Responses;

namespace Petfolio.Application.UseCases.Pets.GetAll
{
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
                    new ResponseShortPetJson {
                         Id = 2,
                        Name = "Luna",
                        Type = Communication.Enums.PetType.Cat
                    }
                }
            };
        }
    }
}