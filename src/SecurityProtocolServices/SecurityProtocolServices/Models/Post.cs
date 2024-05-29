using System;
using System.Collections.Generic;

namespace SecurityProtocolServices.Models;

public partial class Post
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    public override string ToString() => $"{Name}";
    
    public virtual ICollection<User> Users { get; } = new List<User>();
}
