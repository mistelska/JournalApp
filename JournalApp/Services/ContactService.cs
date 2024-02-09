using JournalApp.Entities;
using JournalApp.Repositories;

namespace JournalApp.Services;

internal class ContactService 
{
    private readonly ContactRepository _contactRepository;

    public ContactService(ContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public async Task<Contact> CreateContact(string email, string phoneNumber)
    {
        try
        {
            var entity = await _contactRepository.Get(x => x.Email == email && x.PhoneNumber == phoneNumber);
            if (entity == null)
            {
                entity = await _contactRepository.Create(new Contact { Email = email, PhoneNumber = phoneNumber });
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

    public async Task<Contact> GetContactById(int id)
    {
        try
        {
            var entity = await _contactRepository.Get(x => x.Id == id);
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
    public async Task<Contact> GetCategoryByEmail(string email)
    {
        try
        {
            var entity = await _contactRepository.Get(x => x.Email == email);
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

    public async Task<IEnumerable<Contact>> GetContacts()
    {
        try
        {
            return await _contactRepository.GetAll();
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
            return null!;
        }
    }
    public async Task<Contact> UpdateContact(Contact contact)
    {
        try
        {
            var updatedContact = await _contactRepository.Update(x => x.Id == contact.Id, contact);
            return updatedContact;
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
            return null!;
        }
    }

    public async Task DeleteContactById(int id)
    {
        try
        {
            await _contactRepository.Delete(x => x.Id == id);
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
        }
    }
}
