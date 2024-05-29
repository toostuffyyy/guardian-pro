using System;
using System.Collections.Generic;
using GuardianProAPI.Entities;

namespace GuardianProAPI.ModelsDTO;

public partial class EmployeeDTO
{
    public int Code { get; set; }

    public int? DivisionId { get; set; }

    public int? DepartamentId { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Patronymic { get; set; }
    public DivisionDTO Divisions { get; set; }

    public static EmployeeDTO CreateByEmployee(Employee employee)
    {
        return new EmployeeDTO
        {
            Code = employee.Code,
            DivisionId = employee.DivisionId,
            DepartamentId = employee.DepartmentId,
            LastName = employee.LastName,
            Name = employee.Name,
            Patronymic = employee.Patronymic,
            Divisions = new DivisionDTO()
            {
                Id = employee.DivisionId ?? 0,
                Name = employee.Division.Name
            }
        };
    }
}
