﻿using System;
using System.Collections.Generic;

namespace GuardianProAPI.Entities;

public partial class Gender
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; } = new List<User>();
}
