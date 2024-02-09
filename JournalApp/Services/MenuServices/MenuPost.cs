using System.Reflection;

namespace JournalApp.Services.MenuServices;

internal class MenuPost
{
    private readonly PostService _postService;

    public MenuPost(PostService postService)
    {
        _postService = postService;
    }

    public async Task AddNewPost()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("--Add a New Post--");

            Console.Write("Title: ");
            var title = Console.ReadLine()!;

            Console.Write("Content: ");
            var content = Console.ReadLine()!;

            Console.Write("First Name: ");
            var userFirstName = Console.ReadLine()!;

            Console.Write("Last Name: ");
            var userLastName = Console.ReadLine()!;

            Console.Write("Location: ");
            var location = Console.ReadLine()!;

            Console.Write("Category: ");
            var categoryName = Console.ReadLine()!;

            var newPost = await _postService.CreatePost(title, content, userFirstName, userLastName,location, categoryName);
            if (newPost != null)
            {
                Console.Clear();
                Console.WriteLine("The post is now added to the list.");
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
    public async Task ShowPosts()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("All posts in our System");

            var posts = await _postService.GetPosts();
            foreach (var post in posts)
            {
                Console.WriteLine($"\n{post.Title}\n {post.Content}");
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
    public async Task ShowOnePostById()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Show One Post");
            Console.Write("Type in the post ID-number: ");
            var id = int.Parse(Console.ReadLine()!);

            var post = await _postService.GetPostById(id);
            if (post != null)
            {
                Console.Clear();
                Console.WriteLine($"Post with the ID: {id}");
                Console.WriteLine($"\n{post.Title}\n{post.Content}");
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

    public async Task UpdatePost()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Update Post");
            Console.Write("Type post Id here: ");
            var id = int.Parse(Console.ReadLine()!);

            var post = await _postService.GetPostById(id);
            if (post != null)
            {
                Console.WriteLine($"{post.Title}");

                Console.Write("New Title: ");
                post.Title = Console.ReadLine()!;

                Console.Write("New Content: ");
                post.Content = Console.ReadLine()!;

                var updatedpost = _postService.UpdatePost(post);
                Console.Clear();
                Console.WriteLine("Post updated!");
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
    public async Task DeletePostById()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Delete a Post");
            Console.Write("Post ID-number: ");
            var id = int.Parse(Console.ReadLine()!);

            var post = await _postService.GetPostById(id);
            if (post != null)
            {
                Console.Clear();
                Console.WriteLine($"You are now deleting {post.Title}");
                await _postService.DeletePostById(id);
                Console.WriteLine("Post Deleted!");
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
