using System;
using System.Collections.Generic;
using Azure.Core;
using GuardianProAPI.Entities;

namespace GuardianProWebServis.ModelsDTO;

public partial class VisitorDTO
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public int PassportSeries { get; set; }

    public int PassportNumber { get; set; }

    public string LastName { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Patronymic { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Organization { get; set; }

    public string Notes { get; set; } = null!;

    public DateTime DateOfBirth { get; set; } = DateTime.Now;

    public string? ImagePath { get; set; }

}
