using Microsoft.Extensions.Logging;
using Xunit;

namespace FunctionApp.Test;

public sealed class SmokeTestTest
{
    private ITempInterface _tempInterface;

    public SmokeTestTest(ITempInterface tempInterface) =>
        _tempInterface = tempInterface;

    [Fact]
    public void TempInterfaceMethod()
    {
        _tempInterface.Method();
        Assert.True(true);
    }
}

public sealed class TestTempInterface : ITempInterface
{
    public void Method()
    { }
}
