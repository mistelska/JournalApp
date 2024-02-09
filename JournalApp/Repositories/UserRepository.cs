using JournalApp.Contexts;
using JournalApp.Entities;

namespace JournalApp.Repositories;

internal class UserRepository : GenericRepository<User>
{
    public UserRepository(DataContext context) : base(context)
    {
    }
}
