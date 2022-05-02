using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit.DependencyInjection;
using Xunit.DependencyInjection.Logging;

namespace FunctionApp.Test;

public sealed class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddLogging();

        services.AddTransient<ITempInterface, TestTempInterface>();
    }

    public void Configure(ILoggerFactory loggerFactory, ITestOutputHelperAccessor accessor) =>
        loggerFactory.AddProvider(new XunitTestOutputLoggerProvider(accessor));
}
