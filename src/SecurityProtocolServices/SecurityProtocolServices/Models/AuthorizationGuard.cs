using System;
using System.Collections.Generic;

namespace SecurityProtocolServices.Models;

public partial class AuthorizationGuard
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Passwod { get; set; } = null!;

    public string SecretWord { get; set; } = null!;

    public virtual User IdNavigation { get; set; } = null!;
}
