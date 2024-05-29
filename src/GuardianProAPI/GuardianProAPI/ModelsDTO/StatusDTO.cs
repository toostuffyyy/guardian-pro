using System;
using System.Collections.Generic;
using GuardianProAPI.Entities;

namespace GuardianProAPI.ModelsDTO;

public partial class StatusDTO
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public static StatusDTO CreateByStatus(Status status)
    {
        return new StatusDTO
        {
            Id = status.Id,
            Name = status.Name
        };
    }
}
