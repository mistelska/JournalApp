namespace JournalApp.Services.MenuServices;

internal class MenuContact
{
    private readonly ContactService _contactService;

    public MenuContact(ContactService contactService)
    {
        _contactService = contactService;
    }

    public async Task AddNewContact()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("--Add New Contact--");

            Console.Write("Email: ");
            var email = Console.ReadLine()!;

            Console.Write("Phone Number: ");
            var phoneNumber = Console.ReadLine()!;

            Console.Write("First Name: ");
            var userFirstName = Console.ReadLine()!;

            Console.Write("Last Name: ");
            var userLastName = Console.ReadLine()!;

            var newContact = await _contactService.CreateContact(email, phoneNumber, userFirstName, userLastName);
            if (newContact != null)
            {
                Console.Clear();
                Console.WriteLine("The contact is now added to the list.");
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
    public async Task ShowContacts()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("All Contact-info in our System");

            var contacts = await _contactService.GetContacts();
            foreach (var contact in contacts)
            {
                Console.WriteLine($"\n{contact.Email}");
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
    public async Task ShowOneContactById()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Show One Contact");
            Console.Write("Type in the contact ID-number: ");
            var id = int.Parse(Console.ReadLine()!);

            var contact = await _contactService.GetContactById(id);
            if (contact != null)
            {
                Console.Clear();
                Console.WriteLine($"Contact-info with the ID: {id}");
                Console.WriteLine($"\n{contact.Email}, {contact.PhoneNumber}");
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

    public async Task UpdateContact()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Update contact");
            Console.Write("Type contact Id here: ");
            var id = int.Parse(Console.ReadLine()!);

            var contact = await _contactService.GetContactById(id);
            if (contact != null)
            {
                Console.WriteLine($"{contact.Email}, {contact.PhoneNumber}");

                Console.Write("New Email: ");
                contact.Email = Console.ReadLine()!;

                Console.Write("New Phone Number: ");
                contact.PhoneNumber = Console.ReadLine()!;

                var updatedContact = _contactService.UpdateContact(contact);
                Console.Clear();
                Console.WriteLine("contact updated!");
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
    public async Task DeleteContactById()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Delete a Contact");
            Console.Write("Contact ID-number: ");
            var id = int.Parse(Console.ReadLine()!);

            var contact = await _contactService.GetContactById(id);
            if (contact != null)
            {
                Console.Clear();
                Console.WriteLine($"You are now deleting {contact.Email}");
                await _contactService.DeleteContactById(id);
                Console.WriteLine("Contact-info Deleted!");
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
