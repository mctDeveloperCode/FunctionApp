using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace FunctionApp.Test;

public sealed class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<ITempInterface, TestTempInterface>();
    }
}
