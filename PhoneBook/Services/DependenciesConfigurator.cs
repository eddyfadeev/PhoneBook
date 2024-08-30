using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Enums;
using PhoneBook.Handlers;
using PhoneBook.Interfaces.Handlers;
using PhoneBook.Interfaces.View;
using PhoneBook.Interfaces.View.Factory;
using PhoneBook.Interfaces.View.Factory.Initializer;
using PhoneBook.View;
using PhoneBook.View.Factory;
using PhoneBook.View.Factory.Initializers;

namespace PhoneBook.Services;

internal static class DependenciesConfigurator
{
    private const string JsonFileName = "appsettings.json";

    private static IConfiguration Configuration { get; }
    internal static ServiceCollection ServiceCollection { get; } = new();
    
    static DependenciesConfigurator()
    { 
        Configuration = GetConfiguration().Build();
        ConfigureServices(ServiceCollection);
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<IMenuEntriesInitializer<MainMenu>, MainMenuEntries>();
        services.AddTransient<IMenuEntriesInitializer<SearchMenu>, SearchMenuEntries>();
        services.AddTransient<IMenuEntriesInitializer<ManageMenu>, ManageMenuEntries>();

        services.AddTransient<IMenuCommandsFactory<MainMenu>, MenuCommandsFactory<MainMenu>>();
        services.AddTransient<IMenuCommandsFactory<SearchMenu>, MenuCommandsFactory<SearchMenu>>();
        services.AddTransient<IMenuCommandsFactory<ManageMenu>, MenuCommandsFactory<ManageMenu>>();

        services.AddTransient<IMenuEntries, MenuEntries>();

        services.AddSingleton<MenuHandler<MainMenu>>();
        services.AddSingleton<MenuHandler<SearchMenu>>();
        services.AddSingleton<MenuHandler<ManageMenu>>();
        
        services.AddSingleton<IMenuHandler>(provider => provider.GetRequiredService<MenuHandler<MainMenu>>());
        services.AddSingleton<IMenuHandler>(provider => provider.GetRequiredService<MenuHandler<SearchMenu>>());
        services.AddSingleton<IMenuHandler>(provider => provider.GetRequiredService<MenuHandler<ManageMenu>>());
    }

    private static IConfigurationBuilder GetConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile(JsonFileName, optional: false, reloadOnChange: true);

        return builder;
    }
}