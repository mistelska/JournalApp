using JournalApp.Contexts;
using JournalApp.Entities;

namespace JournalApp.Repositories;

internal class ContactRepository : GenericRepository<Contact>
{
    public ContactRepository(DataContext context) : base(context)
    {
    }
}
