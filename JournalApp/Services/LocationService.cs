using JournalApp.Entities;
using JournalApp.Repositories;

namespace JournalApp.Services;

internal class LocationService
{
    private readonly LocationRepository _locationRepository;

    public LocationService(LocationRepository locationRepository)
    {
        _locationRepository = locationRepository;
    }

    public async Task<Location> CreateLocation(string location)
    {
        try
        {
            var entity = await _locationRepository.Get(x => x.Location1 == location); // ändra location1
            if (entity == null)
            {
                entity = await _locationRepository.Create(new Location { Location1 = location});
            }
            return entity;
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
            return null!;
        }
    }

    public async Task<Location> GetLocationById(int id)
    {
        try
        {
            var entity = await _locationRepository.Get(x => x.Id == id);
            return entity;
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
            return null!;
        }
    }

    public async Task<IEnumerable<Location>> GetLocations()
    {
        try
        {
            return await _locationRepository.GetAll();
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
            return null!;
        }
    }
    public async Task<Location> UpdateLocation(Location location)
    {
        try
        {
            var updatedLocation = await _locationRepository.Update(x => x.Id == location.Id, location);
            return updatedLocation;
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
            return null!;
        }
    }

    public async Task DeleteLocationById(int id)
    {
        try
        {
            await _locationRepository.Delete(x => x.Id == id);
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
        }
    }
}
