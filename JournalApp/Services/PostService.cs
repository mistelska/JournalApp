using JournalApp.Entities;
using JournalApp.Repositories;

namespace JournalApp.Services;

internal class PostService
{
    private readonly PostRepository _postRepository;

    public PostService(PostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<Post> CreatePost(string title, string content)
    {
        try
        {
            var entity = await _postRepository.Get(x => x.Title == title && x.Content == content); // ändra location1
            if (entity == null)
            {
                entity = await _postRepository.Create(new Post { Title = title, Content = content});
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
