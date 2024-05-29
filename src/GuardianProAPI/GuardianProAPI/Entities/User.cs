using System;
using System.Collections.Generic;

namespace GuardianProAPI.Entities;

public partial class User
{
    public int Id { get; set; }

    public int PostId { get; set; }

    public int? TypeUserId { get; set; }

    public int GenderId { get; set; }

    public int StatusId { get; set; }

    public string LastName { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Patronymic { get; set; }

    public virtual AuthorizationGuard? AuthorizationGuard { get; set; }

    public virtual Gender Gender { get; set; } = null!;

    public virtual Post Post { get; set; } = null!;

    public virtual StatusGuard Status { get; set; } = null!;

    public virtual TypeUser? TypeUser { get; set; }
}
