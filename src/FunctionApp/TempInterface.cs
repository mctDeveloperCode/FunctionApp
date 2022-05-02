using Microsoft.Extensions.Logging;

public interface ITempInterface
{
    void Method();
}

public sealed class TempInterfaceImpl : ITempInterface
{
    private ILogger<ITempInterface> _logger;

    public TempInterfaceImpl(ILogger<ITempInterface> logger) =>
        _logger = logger;

    public void Method() =>
        _logger.LogInformation("Method in production");
}
