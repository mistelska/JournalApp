using System;
using System.Collections.Generic;

namespace JournalApp.Entities;

public partial class Contact
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
