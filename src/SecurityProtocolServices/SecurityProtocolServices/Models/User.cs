using System;
using System.Collections.Generic;

namespace SecurityProtocolServices.Models;

public partial class User
{
    public int Id { get; set; }

    public int? PostId { get; set; }

    public int? TypeUserId { get; set; }

    public int GenderId { get; set; }

    public int StatusId { get; set; }

    public string LastName { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Patronymic { get; set; }

    public bool? Approved { get; set; }

    public bool IsMandates { get; set; }

    public bool AddDataRute { get; set; }

    public bool LookDataRute { get; set; }

    public bool ReportRute { get; set; }
    public override string ToString() => $"{Name} {LastName[0]}. {Patronymic[0]}.";

    public virtual AuthorizationGuard? AuthorizationGuard { get; set; }

    public virtual Gender Gender { get; set; } = null!;

    public virtual Post? Post { get; set; }

    public virtual StatusGuard Status { get; set; } = null!;

    public virtual TypeUser? TypeUser { get; set; }
}
