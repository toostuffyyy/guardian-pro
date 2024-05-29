using System;
using System.Collections.Generic;

namespace GuardianProAPI.Entities;

public partial class TypeOrder
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
