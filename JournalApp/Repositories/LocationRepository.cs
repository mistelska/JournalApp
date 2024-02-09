using JournalApp.Contexts;
using JournalApp.Entities;

namespace JournalApp.Repositories;

internal class LocationRepository : GenericRepository<Location>
{
    public LocationRepository(DataContext context) : base(context)
    {
    }
}
