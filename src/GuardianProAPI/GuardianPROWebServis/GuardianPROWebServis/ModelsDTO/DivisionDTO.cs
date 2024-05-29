
using System;
using System.Collections.Generic;
using System.Linq;

namespace GuardianPROWebServis.ModelDTO
{
    public partial class DivisionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public virtual List<EmployeeDTO> Employees { get; set; }
        /*
        public static DivisionDTO CreateByEmployee(Division division)
        {
            return new DivisionDTO()
            {
                Id = division.Id,
                Name = division.Name,
                Employees = division.Employees.Select(employee =>
                    EmployeeDTO.CreateByEmployee(employee)).ToList()
            };
        }
        */
    }
}
