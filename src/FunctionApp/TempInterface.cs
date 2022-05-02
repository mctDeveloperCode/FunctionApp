using System;
using Microsoft.Extensions.Logging;

public interface ITempInterface
{
    void Method();
}

public sealed class TempInterfaceImpl : ITempInterface
{
    private ILogger<ITempInterface> _logger;
    private Guid _id = new Guid();

    public TempInterfaceImpl(ILogger<ITempInterface> logger) =>
        _logger = logger;

    public void Method() =>
        _logger.LogInformation("TempInterfaceImpl {id}", _id.ToString());
}
