using JournalApp;
using JournalApp.Contexts;
using JournalApp.Repositories;
using JournalApp.Services;
using JournalApp.Services.MenuServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddDbContext<DataContext>(x => x.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\all-courses-ec\\data-storage-course\\JournalApp\\JournalApp\\Data\\databasejournalapp.mdf;Integrated Security=True;Connect Timeout=30"));
    
    services.AddScoped<CategoryRepository>();
    services.AddScoped<ContactRepository>();
    services.AddScoped<LocationRepository>();
    services.AddScoped<PostRepository>();
    services.AddScoped<UserRepository>();

    services.AddScoped<CategoryService>();
    services.AddScoped<ContactService>();
    services.AddScoped<LocationService>();
    services.AddScoped<PostService>();
    services.AddScoped<UserService>();

    services.AddSingleton<MenuCategory>();
    services.AddSingleton<MenuContact>();
    services.AddSingleton<MenuLocation>();
    services.AddSingleton<MenuPost>();
    services.AddSingleton<MenuUser>();

    services.AddSingleton<ConsoleApp>();
}).Build();

using (var scope = builder.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;

    var studyManagementMenu = serviceProvider.GetRequiredService<ConsoleApp>();

    await studyManagementMenu.MainMenu();
}