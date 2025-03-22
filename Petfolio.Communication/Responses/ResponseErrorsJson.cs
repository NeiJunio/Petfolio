namespace Petfolio.Communication.Responses;

public class ResponseErrorsJson
{
    public List<string> Errors { get; set; } = [];
    // cria a lista vazia, mas não nula
    // Quando a gente instanciar a classe ResponseErrorsJson, o Errors ja receberá uma instância vazia, ficando assim, pronto para receber os erros        
}
