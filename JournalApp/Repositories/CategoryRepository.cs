using JournalApp.Contexts;
using JournalApp.Entities;

namespace JournalApp.Repositories;

internal class CategoryRepository : GenericRepository<Category>
{
    public CategoryRepository(DataContext context) : base(context)
    {
    }
}
