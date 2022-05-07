using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(MctLearnAzure.FunctionApp.Startup))]

namespace MctLearnAzure.FunctionApp;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder) =>
        builder.Services
            .AddSingleton<ITempInterface, TempInterfaceImpl>()
            .AddConfiguration(builder.GetContext());
}

internal static class StartupExtensions
{
    public static IServiceCollection AddConfiguration(this IServiceCollection serviceCollection, FunctionsHostBuilderContext context) =>
        serviceCollection.AddSingleton(
            new ConfigurationBuilder()
                .SetBasePath(context.ApplicationRootPath)
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build()
        );
}
