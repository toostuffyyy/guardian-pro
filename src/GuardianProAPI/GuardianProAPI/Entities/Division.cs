﻿using System;
using System.Collections.Generic;

namespace GuardianProAPI.Entities;

public partial class Division
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
