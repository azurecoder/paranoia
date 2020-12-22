using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using Paranoia.App;

namespace Paranoia
{
    public class GenerateCharacter
    {
        [FunctionName("GenerateCharacter")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Generating a new character for ...");
            var clone = CharacterGenerator.NewCharacter();
            log.LogInformation("Completed generating new character ...");

            return new OkObjectResult(clone);
        }
    }
}
