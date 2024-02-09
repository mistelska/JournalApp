using JournalApp.Entities;
using JournalApp.Repositories;

namespace JournalApp.Services;

internal class UserService
{
    private readonly UserRepository _userRepository;

    public UserService(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> CreateUser(string firstName, string lastName)
    {
        try
        {
            var entity = await _userRepository.Get(x => x.FirstName == firstName && x.LastName == lastName); // ändra location1
            if (entity == null)
            {
                entity = await _userRepository.Create(new User { FirstName = firstName, LastName = lastName });
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

    public async Task<User> GetUserById(int id)
    {
        try
        {
            var entity = await _userRepository.Get(x => x.Id == id);
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

    public async Task<IEnumerable<User>> GetUsers()
    {
        try
        {
            return await _userRepository.GetAll();
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
            return null!;
        }
    }
    public async Task<User> UpdateUser(User user)
    {
        try
        {
            var updatedUser = await _userRepository.Update(x => x.Id == user.Id, user);
            return updatedUser;
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
            return null!;
        }
    }

    public async Task DeleteUserById(int id)
    {
        try
        {
            await _userRepository.Delete(x => x.Id == id);
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
        }
    }
}
