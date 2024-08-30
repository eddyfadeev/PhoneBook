using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Enums;
using PhoneBook.Extensions;
using PhoneBook.Handlers;
using PhoneBook.Services;
using PhoneBook.View;
using Spectre.Console;

namespace PhoneBook;

internal static class Program
{
    static void Main(string[] args)
    {
        var services = DependenciesConfigurator.ServiceCollection;
        var serviceProvider = services.BuildServiceProvider();
        
        var menuHandler = serviceProvider.GetRequiredService<MenuHandler<MainMenu>>();
        
        menuHandler.HandleMenu();
    }
}