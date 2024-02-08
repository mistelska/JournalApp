using System;
using System.Collections.Generic;

namespace JournalApp.Entities;

public partial class Post
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public int UserId { get; set; }

    public int LocationId { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Location Location { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
