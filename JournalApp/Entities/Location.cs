using System;
using System.Collections.Generic;

namespace JournalApp.Entities;

public partial class Location
{
    public int Id { get; set; }

    public string Location1 { get; set; } = null!;

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
