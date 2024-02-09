using JournalApp.Entities;
using JournalApp.Repositories;

namespace JournalApp.Services;

internal class PostService
{
    private readonly PostRepository _postRepository;
    private readonly UserService _userService;
    private readonly LocationService _locationService;
    private readonly CategoryService _categoryService;

    public PostService(PostRepository postRepository, UserService userService, LocationService locationService, CategoryService categoryService)
    {
        _postRepository = postRepository;
        _userService = userService;
        _locationService = locationService;
        _categoryService = categoryService;
    }

    public async Task<Post> CreatePost(string title, string content, string userFirstName, string userLastName, string location, string categoryName)
    {
        try
        {
            var userEntity = await _userService.CreateUser(userFirstName, userLastName);
            var locationEntity = await _locationService.CreateLocation(location);
            var categoryEntity = await _categoryService.CreateCategory(categoryName);

            var entity = await _postRepository.Get(x => x.Title == title && x.Content == content); 
            if (entity == null)
            {
                entity = await _postRepository.Create(new Post { Title = title, Content = content, UserId = userEntity.Id, LocationId = locationEntity.Id, CategoryId = categoryEntity.Id });
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

    public async Task<Post> GetPostById(int id)
    {
        try
        {
            var entity = await _postRepository.Get(x => x.Id == id);
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

    public async Task<IEnumerable<Post>> GetPosts()
    {
        try
        {
            return await _postRepository.GetAll();
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
            return null!;
        }
    }
    public async Task<Post> UpdatePost(Post post)
    {
        try
        {
            var updatedPost = await _postRepository.Update(x => x.Id == post.Id, post);
            return updatedPost;
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
            return null!;
        }
    }

    public async Task DeletePostById(int id)
    {
        try
        {
            await _postRepository.Delete(x => x.Id == id);
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
        }
    }
}
