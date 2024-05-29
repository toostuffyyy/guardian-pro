using System;

namespace GuardTerminal.ModelsDTO;

public partial class TypeUserDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public override string ToString() => $"{Name}";
}
