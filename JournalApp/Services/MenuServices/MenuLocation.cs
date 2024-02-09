namespace JournalApp.Services.MenuServices;

internal class MenuLocation
{
    private readonly LocationService _locationService;

    public MenuLocation(LocationService locationService)
    {
        _locationService = locationService;
    }

    public async Task AddNewLocation()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("--Add New Location--");

            Console.Write("Location: ");
            var location = Console.ReadLine()!;

            var newLocation = await _locationService.CreateLocation(location);
            if (newLocation != null)
            {
                Console.Clear();
                Console.WriteLine("The location is now added to the list.");
                Console.ReadLine();
            }
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
        }
    }
    public async Task ShowLocations()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("All Locations in our System");

            var locations = await _locationService.GetLocations();
            foreach (var location in locations)
            {
                Console.WriteLine($"\n{location.Location1}");
            }
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
        }
    }
    public async Task ShowOneLocationById()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Show One Location");
            Console.Write("Type in the location ID-number: ");
            var id = int.Parse(Console.ReadLine()!);

            var location = await _locationService.GetLocationById(id);
            if (location != null)
            {
                Console.Clear();
                Console.WriteLine($"Location with the ID: {id}");
                Console.WriteLine($"\n{location.Location1}");
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
        }
    }

    public async Task UpdateLocation()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Update Location");
            Console.Write("Type location Id here: ");
            var id = int.Parse(Console.ReadLine()!);

            var location = await _locationService.GetLocationById(id);
            if (location != null)
            {
                Console.WriteLine($"{location.Location1}");

                Console.Write("New Location: ");
                location.Location1 = Console.ReadLine()!;

                var updatedLocation = _locationService.UpdateLocation(location);
                Console.Clear();
                Console.WriteLine("Location updated!");
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
        }
    }
    public async Task DeleteLocationById()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Delete a Location");
            Console.Write("Location ID-number: ");
            var id = int.Parse(Console.ReadLine()!);

            var location = await _locationService.GetLocationById(id);
            if (location != null)
            {
                Console.Clear();
                Console.WriteLine($"You are now deleting {location.Location1}");
                await _locationService.DeleteLocationById(id);
                Console.WriteLine("location-info Deleted!");
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
        }
    }
}
