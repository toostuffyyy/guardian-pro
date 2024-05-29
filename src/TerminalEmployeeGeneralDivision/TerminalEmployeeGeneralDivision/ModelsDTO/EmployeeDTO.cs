using System;
using System.Collections.Generic;

namespace TerminalEmployeeGeneralDivision.ModelsDTO;

public partial class EmployeeDTO
{
    public int Code { get; set; }

    public int? DivisionId { get; set; }

    public int? DepartamentId { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Patronymic { get; set; }
    public DivisionDTO Divisions { get; set; }

}
