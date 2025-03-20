using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petfolio.Communication.Responses
{
    public class ResponseAllPetJson
    {
        public List<ResponseShortPetJson> Pets { get; set; } = [];
    }
}