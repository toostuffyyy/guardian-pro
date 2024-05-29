using System;
using System.Collections.Generic;

namespace GuardianProAPI.Entities;

public partial class Employee
{
    public int Code { get; set; }

    public int? DivisionId { get; set; }

    public int? DepartmentId { get; set; }

    public string LastName { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Patronymic { get; set; }

    public virtual Department? Department { get; set; }

    public virtual Division? Division { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
