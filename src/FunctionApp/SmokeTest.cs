using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace MctLearnAzure.FunctionApp
{
    public sealed class SmokeTest
    {
        private ITempInterface _tempInterface;
        private ILogger<SmokeTest> _logger;

        public SmokeTest(ITempInterface tempInterface, ILogger<SmokeTest> logger) =>
            (_tempInterface, _logger) = (tempInterface, logger);

        [FunctionName("SmokeTest")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req)
        {
            string? name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            _logger.LogInformation("C# HTTP trigger function processed a request. {name}", string.IsNullOrWhiteSpace(name) ? "<EMPTY>" : name);

            string responseMessage = GetResponseString(name);

            return new OkObjectResult(responseMessage);
        }

        public string GetResponseString(string? name)
        {
            _tempInterface.Method();

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return responseMessage;
        }
    }
}
