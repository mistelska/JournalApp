using System;
using System.Collections.Generic;

namespace JournalApp.Entities;

public partial class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public virtual Contact? Contact { get; set; }

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
