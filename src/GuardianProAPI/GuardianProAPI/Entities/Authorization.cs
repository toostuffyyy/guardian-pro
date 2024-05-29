using System;
using System.Collections.Generic;

namespace GuardianProAPI.Entities;

public partial class Authorization
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual Email EmailNavigation { get; set; } = null!;
}
