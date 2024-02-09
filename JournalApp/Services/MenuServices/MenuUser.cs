namespace JournalApp.Services.MenuServices;

internal class MenuUser
{
    private readonly UserService _userService;

    public MenuUser(UserService userService)
    {
        _userService = userService;
    }

    public async Task AddNewUser()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("--Add a New User--");

            Console.Write("First Name: ");
            var firstName = Console.ReadLine()!;

            Console.Write("Last Name: ");
            var lastName = Console.ReadLine()!;

            var newUser = await _userService.CreateUser(firstName, lastName);
            if (newUser != null)
            {
                Console.Clear();
                Console.WriteLine("The user is now added to the list.");
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
    public async Task ShowUsers()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("All users in our System");

            var users = await _userService.GetUsers();
            foreach (var user in users)
            {
                Console.WriteLine($"\n{user.FirstName} {user.LastName}");
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
    public async Task ShowOneUserById()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Show One User");
            Console.Write("Type in the user ID-number: ");
            var id = int.Parse(Console.ReadLine()!);

            var user = await _userService.GetUserById(id);
            if (user != null)
            {
                Console.Clear();
                Console.WriteLine($"user with the ID: {id}");
                Console.WriteLine($"\n{user.FirstName} {user.LastName}");
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

    public async Task UpdateUser()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Update User");
            Console.Write("Type user Id here: ");
            var id = int.Parse(Console.ReadLine()!);

            var user = await _userService.GetUserById(id);
            if (user != null)
            {
                Console.WriteLine($"{user.FirstName} {user.LastName}");

                Console.Write("New First Name: ");
                user.FirstName = Console.ReadLine()!;

                Console.Write("New Last Name: ");
                user.LastName = Console.ReadLine()!;

                var updateduser = _userService.UpdateUser(user);
                Console.Clear();
                Console.WriteLine("User updated!");
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
    public async Task DeleteUserById()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Delete a User");
            Console.Write("User ID-number: ");
            var id = int.Parse(Console.ReadLine()!);

            var user = await _userService.GetUserById(id);
            if (user != null)
            {
                Console.Clear();
                Console.WriteLine($"You are now deleting {user.FirstName} {user.LastName}");
                await _userService.DeleteUserById(id);
                Console.WriteLine("User Deleted!");
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
