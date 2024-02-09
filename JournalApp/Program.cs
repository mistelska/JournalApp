using JournalApp.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder();

builder.ConfigureServices(services =>
{
    services.AddDbContext<DataContext>(x => x.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\all-courses-ec\\data-storage-course\\JournalApp\\JournalApp\\Data\\databasejournalapp.mdf;Integrated Security=True;Connect Timeout=30"));
});

builder.Build();