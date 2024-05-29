﻿using System;
using System.Collections.Generic;

namespace SecurityProtocolServices.Models;

public partial class Status
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
