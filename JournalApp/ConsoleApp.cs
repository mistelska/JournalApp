using JournalApp.Services.MenuServices;

namespace JournalApp;

internal class ConsoleApp
{
    private readonly MenuCategory _menuCategory;
    private readonly MenuContact _menuContact;
    private readonly MenuLocation _menuLocation;
    private readonly MenuPost _menuPost;
    private readonly MenuUser _menuUser;

    public ConsoleApp(MenuCategory menuCategory, MenuContact menuContact, MenuLocation menuLocation, MenuPost menuPost, MenuUser menuUser)
    {
        _menuCategory = menuCategory;
        _menuContact = menuContact;
        _menuLocation = menuLocation;
        _menuPost = menuPost;
        _menuUser = menuUser;
    }

    public async Task MainMenu()
    {
        bool goingMainMenu = true;
        while (goingMainMenu)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Journal-Application!");
            Console.WriteLine("\n[1] Create New..");
            Console.WriteLine("[2] Show all..");
            Console.WriteLine("[3] Show one..");
            Console.WriteLine("[4] Update..");
            Console.WriteLine("[5] Delete..");
            Console.WriteLine("[6] Quit");
            int.TryParse(Console.ReadLine(), out var option);
            switch (option)
            {
                case 1:
                    bool goingCreateMenu = true;
                    while (goingCreateMenu)
                    {
                        Console.Clear();
                        Console.WriteLine("Create a new..");
                        Console.WriteLine("\n[1] Post");
                        Console.WriteLine("[2] User");
                        Console.WriteLine("[3] Contact-Information");
                        Console.WriteLine("[4] Category");
                        Console.WriteLine("[5] Location");
                        Console.WriteLine("[6] Back to Main Menu");
                        int.TryParse(Console.ReadLine(), out var optionCreate);
                        switch (optionCreate)
                        {
                            case 1:
                                await _menuPost.AddNewPost();
                                break;
                            case 2:
                                await _menuUser.AddNewUser();
                                break;
                            case 3:
                                await _menuContact.AddNewContact();
                                break;
                            case 4:
                                await _menuCategory.AddNewCategory();
                                break;
                            case 5:
                                await _menuLocation.AddNewLocation();
                                break;
                            case 6:
                                goingCreateMenu = false;
                                break;
                            default:
                                Console.WriteLine("Invalid input! Choose between 1-6, please.");
                                Console.ReadKey();
                                break;
                        }
                    }
                    break;
                case 2:
                    bool goingShowAllMenu = true;
                    while (goingShowAllMenu)
                    {
                        Console.Clear();
                        Console.WriteLine("Show All..");
                        Console.WriteLine("\n[1] Post");
                        Console.WriteLine("[2] User");
                        Console.WriteLine("[3] Contact-Information");
                        Console.WriteLine("[4] Category");
                        Console.WriteLine("[5] Location");
                        Console.WriteLine("[6] Back to Main Menu");
                        int.TryParse(Console.ReadLine(), out var optionShowAll);

                        switch (optionShowAll)
                        {
                            case 1:
                                await _menuPost.ShowPosts();
                                break;
                            case 2:
                                await _menuUser.ShowUsers();
                                break;
                            case 3:
                                await _menuContact.ShowContacts();
                                break;
                            case 4:
                                await _menuLocation.ShowLocations();
                                break;
                            case 5:
                                await _menuCategory.ShowCategories();
                                break;
                            case 6:
                                goingShowAllMenu = false;
                                break;
                            default:
                                Console.WriteLine("Invalid input! Choose between 1-6, please.");
                                Console.ReadKey();
                                break;
                        }
                    }
                    break;
                case 3:
                    bool goingShowOneMenu = true;
                    while (goingShowOneMenu)
                    {
                        Console.Clear();
                        Console.WriteLine("Show one of..");
                        Console.WriteLine("\n[1] Post");
                        Console.WriteLine("[2] User");
                        Console.WriteLine("[3] Contact-Information");
                        Console.WriteLine("[4] Category");
                        Console.WriteLine("[5] Location");
                        Console.WriteLine("[6] Back to Main Menu");
                        int.TryParse(Console.ReadLine(), out var optionShowOne);

                        switch (optionShowOne)
                        {
                            case 1:
                                await _menuPost.ShowOnePostById();
                                break;
                            case 2:
                                await _menuUser.ShowOneUserById();
                                break;
                            case 3:
                                await _menuContact.ShowOneContactById();
                                break;
                            case 4:
                                await _menuCategory.ShowOneCategoryById();
                                break;
                            case 5:
                                await _menuLocation.ShowOneLocationById();
                                break;
                            case 6:
                                goingShowOneMenu = false;
                                break;
                            default:
                                Console.WriteLine("Invalid input! Choose between 1-6, please.");
                                Console.ReadKey();
                                break;
                        }
                    }
                    break;
                case 4:
                    bool goingUpdateMenu = true;
                    while (goingUpdateMenu)
                    {
                        Console.Clear();
                        Console.WriteLine("Update..");
                        Console.WriteLine("\n[1] Post");
                        Console.WriteLine("[2] User");
                        Console.WriteLine("[3] Contact-Information");
                        Console.WriteLine("[4] Category");
                        Console.WriteLine("[5] Location");
                        Console.WriteLine("[6] Back to Main Menu");
                        int.TryParse(Console.ReadLine(), out var optionUpdate);

                        switch (optionUpdate)
                        {
                            case 1:
                                await _menuPost.UpdatePost();
                                break;
                            case 2:
                                await _menuUser.UpdateUser();
                                break;
                            case 3:
                                await _menuContact.UpdateContact();
                                break;
                            case 4:
                                await _menuCategory.UpdateCategory();
                                break;
                            case 5:
                                await _menuLocation.UpdateLocation();
                                break;
                            case 6:
                                goingUpdateMenu = false;
                                break;
                            default:
                                Console.WriteLine("Invalid input! Choose between 1-6, please.");
                                Console.ReadKey();
                                break;
                        }
                    }
                    break;
                case 5:
                    bool goingDeleteMenu = true;
                    while (goingDeleteMenu)
                    {
                        Console.Clear();
                        Console.WriteLine("Delete..");
                        Console.WriteLine("\n[1] Post");
                        Console.WriteLine("[2] User");
                        Console.WriteLine("[3] Contact-Information");
                        Console.WriteLine("[4] Category");
                        Console.WriteLine("[5] Location");
                        Console.WriteLine("[6] Back to Main Menu");
                        int.TryParse(Console.ReadLine(), out var optionDelete);

                        switch (optionDelete)
                        {
                            case 1:
                                await _menuPost.DeletePostById();
                                break;
                            case 2:
                                await _menuUser.DeleteUserById();
                                break;
                            case 3:
                                await _menuContact.DeleteContactById();
                                break;
                            case 4:
                                await _menuCategory.DeleteCategoryById();
                                break;
                            case 5:
                                await _menuLocation.DeleteLocationById();
                                break;
                            case 6:
                                goingDeleteMenu = false;
                                break;
                            default:
                                Console.WriteLine("Invalid input! Choose between 1-6, please.");
                                Console.ReadKey();
                                break;
                        }
                    }
                    break;
                case 6:
                    Console.Clear();
                    Console.WriteLine("You are now exiting this program.");
                    goingMainMenu = false;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid input! Choose between 1-6, please.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
