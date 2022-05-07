using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace MctLearnAzure.FunctionApp
{
    public sealed class SmokeTest
    {
        private ITempInterface _tempInterface;
        private ILogger<SmokeTest> _logger;
        private IConfiguration _configuration;

        public SmokeTest(ITempInterface tempInterface, ILogger<SmokeTest> logger, IConfiguration configuration) =>
            (_tempInterface, _logger, _configuration) = (tempInterface, logger, configuration);

        [FunctionName("SmokeTest")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req)
        {
            string? name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            _logger.LogInformation("*********************************");
            _logger.LogInformation("name: {name}", name);

            _logger.LogInformation("MySetting is '{MySetting}'", _configuration.GetValue<string>("MySetting"));

            return new OkObjectResult(GetResponseString(name));
        }

        public string GetResponseString(string? name)
        {
            _tempInterface.Method();

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            responseMessage = $"{responseMessage}\n\n{_configuration["MySetting"]}";

            return responseMessage;
        }
    }
}
