using JournalApp.Entities;
using JournalApp.Repositories;

namespace JournalApp.Services;

internal class CategoryService
{
    private readonly CategoryRepository _categoryRepository;

    public CategoryService(CategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Category> CreateCategory(string categoryName)
    {
        try
        {
            var entity = await _categoryRepository.Get(x => x.CategoryName == categoryName);
            if (entity == null)
            {
                entity = await _categoryRepository.Create(new Category { CategoryName = categoryName });
            }
            return entity;
        }
        catch(Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
            return null!;
        }
    }

    public async Task <Category> GetCategoryById(int id)
    {
        try
        {
            var entity = await _categoryRepository.Get(x => x.Id == id);
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
    public async Task<Category> GetCategoryByName(string categoryName)
    {
        try
        {
            var entity = await _categoryRepository.Get(x => x.CategoryName == categoryName);
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

    public async Task<IEnumerable<Category>> GetCategories()
    {
        try
        {
            return await _categoryRepository.GetAll();
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
            return null!;
        }
    }
    public async Task<Category> UpdateCategory(Category category)
    {
        try
        {
            var updatedCategory = await _categoryRepository.Update(x => x.Id == category.Id, category);
            return updatedCategory;
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
            return null!;
        }
    }

    public async Task DeleteCategoryById(int id)
    {
        try
        {
            await _categoryRepository.Delete(x => x.Id == id);
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
        }
    }
}
