using System;
using System.Collections.Generic;

namespace GuardianProAPI.Entities;

public partial class StatusGuard
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; } = new List<User>();
}
