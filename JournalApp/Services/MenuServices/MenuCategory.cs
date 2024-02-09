namespace JournalApp.Services.MenuServices;

internal class MenuCategory
{
    private readonly CategoryService _categoryService;

    public MenuCategory(CategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task AddNewCategory()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("--Add New Category--");

            Console.Write("Category Name: ");
            var categoryName = Console.ReadLine()!;

            var newCategory = await _categoryService.CreateCategory(categoryName);
            if (newCategory != null)
            {
                Console.Clear();
                Console.WriteLine("The category is now added to the list.");
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
    public async Task ShowCategories()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("All Categories in our System");

            var categories = await _categoryService.GetCategories();
            foreach (var category in categories)
            {
                Console.WriteLine($"\n{category.CategoryName}");
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
    public async Task ShowOneCategoryById()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Show One Category");
            Console.Write("Type in the category ID-number: ");
            var id = int.Parse(Console.ReadLine()!);

            var category = await _categoryService.GetCategoryById(id);
            if (category != null)
            {
                Console.Clear();
                Console.WriteLine($"Category with the ID: {id}");
                Console.WriteLine($"\n{category.CategoryName}");
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

    public async Task UpdateCategory()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Update Category");
            Console.Write("Type Category Id here: ");
            var id = int.Parse(Console.ReadLine()!);

            var category = await _categoryService.GetCategoryById(id);
            if (category != null)
            {
                Console.WriteLine($"{category.CategoryName}");

                Console.Write("New Category: ");
                category.CategoryName = Console.ReadLine()!;

                var updatedCategory = _categoryService.UpdateCategory(category);
                Console.Clear();
                Console.WriteLine("Category updated!");
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
    public async Task DeleteCategoryById()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Delete a Category");
            Console.Write("Category ID-number: ");
            var id = int.Parse(Console.ReadLine()!);

            var category = await _categoryService.GetCategoryById(id);
            if (category != null)
            {
                Console.Clear();
                Console.WriteLine($"You are now deleting {category.CategoryName}.");
                await _categoryService.DeleteCategoryById(id);
                Console.WriteLine("Course Deleted!");
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
