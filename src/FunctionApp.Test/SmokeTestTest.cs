using MctLearnAzure.FunctionApp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Xunit;

namespace FunctionApp.Test;

public sealed class SmokeTestTest
{
    private ITempInterface _tempInterface;
    private ILogger<SmokeTest> _smokeTestLogger;
    private IConfiguration _configuration;

    public SmokeTestTest(ITempInterface tempInterface, ILogger<SmokeTest> smokeTestLogger, IConfiguration configuration) =>
        (_tempInterface, _smokeTestLogger, _configuration) = (tempInterface, smokeTestLogger, configuration);

    [Fact]
    public void TempInterfaceMethod()
    {
        SmokeTest smokeTest = new (_tempInterface, _smokeTestLogger, _configuration);
        var result = smokeTest.GetResponseString("mike");

        // TODO: Get congiguration working in test!!
        _smokeTestLogger.LogInformation($"MySetting is '{_configuration["MySetting"]}'");

        Assert.True(true);
    }
}

public sealed class TestTempInterface : ITempInterface
{
    private ILogger<TestTempInterface> _logger;

    public TestTempInterface(ILogger<TestTempInterface> logger) =>
        _logger = logger;

    public void Method() =>
        _logger.LogInformation("Method in test.");
}
