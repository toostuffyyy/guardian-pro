using System;
using System.Collections.Generic;
using GuardianProAPI.Entities;

namespace GuardianProAPI.ModelsDTO;

public partial class DivisionDTO
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual List<EmployeeDTO> Employees { get; set; }

    public static DivisionDTO CreateByDivision(Division division)
    {
        return new DivisionDTO()
        {
            Id = division.Id,
            Name = division.Name,
            Employees = division.Employees.Select(a => 
                EmployeeDTO.CreateByEmployee(a)).ToList()
        };
    }
}
