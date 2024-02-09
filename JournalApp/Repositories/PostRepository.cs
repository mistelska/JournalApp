using JournalApp.Contexts;
using JournalApp.Entities;

namespace JournalApp.Repositories;

internal class PostRepository : GenericRepository<Post>
{
    public PostRepository(DataContext context) : base(context)
    {
    }
}
