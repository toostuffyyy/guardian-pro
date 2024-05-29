using System;
using System.Collections.Generic;
namespace TerminalEmployeeGeneralDivision.ModelsDTO;

public partial class TypeOrderDTO
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    public override string ToString() => $"{Name}";
}
