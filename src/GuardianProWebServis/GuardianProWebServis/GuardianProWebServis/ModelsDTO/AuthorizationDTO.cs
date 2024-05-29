using System;
using System.Collections.Generic;
using GuardianProAPI.ModelsDTO;
using Microsoft.EntityFrameworkCore;

namespace GuardianProWebServis.ModelsDTO;

public partial class AuthorizationDTO
{
    public int Id { get; set; }

    public string Email { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;
}
