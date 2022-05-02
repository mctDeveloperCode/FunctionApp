using MctLearnAzure.FunctionApp;
using Microsoft.Extensions.Logging;
using Xunit;

namespace FunctionApp.Test;

public sealed class SmokeTestTest
{
    private ITempInterface _tempInterface;
    private ILogger<SmokeTest> _smokeTestLogger;

    public SmokeTestTest(ITempInterface tempInterface, ILogger<SmokeTest> smokeTestLogger) =>
        (_tempInterface, _smokeTestLogger) = (tempInterface, smokeTestLogger);

    [Fact]
    public void TempInterfaceMethod()
    {
        SmokeTest smokeTest = new (_tempInterface, _smokeTestLogger);
        var result = smokeTest.GetResponseString("mike");
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
