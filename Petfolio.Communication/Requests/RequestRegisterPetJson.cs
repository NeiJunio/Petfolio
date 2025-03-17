using Petfolio.Communication.Enums;

namespace Petfolio.Communication.Requests;
public class RequestRegisterPetJson
{
    public string Name { get; set; } = string.Empty; // Nome nunca vai ser nulo, no máximo uma string vazia
    public DateTime Birthday { get; set; }
    public PetType Type { get; set; }
}
