using System;
using System.Collections.Generic;

namespace GuardianProEmployeeDivision.ModelsDTO;

public partial class EmployeeDTO
{
    public int Code { get; set; }

    public int? DivisionId { get; set; }

    public int? DepartamentId { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Patronymic { get; set; }

    public virtual DivisionDTO? Division { get; set; }

}
