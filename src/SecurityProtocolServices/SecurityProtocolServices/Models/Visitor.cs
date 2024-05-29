using System;
using System.Collections.Generic;

namespace SecurityProtocolServices.Models;

public partial class Visitor
{
    public int Id { get; set; }

    public int PassportSeries { get; set; }

    public int PassportNumber { get; set; }

    public string LastName { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Patronymic { get; set; }

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? Organization { get; set; }

    public string Notes { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public string? ImagePath { get; set; }

    public virtual Email EmailNavigation { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
