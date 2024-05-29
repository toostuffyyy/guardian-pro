using System;
using System.Collections.Generic;
using GuardianProAPI.Entities;

namespace GuardianProAPI.ModelsDTO;

public partial class TypeOrderDTO
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public static TypeOrderDTO CreateByTypeOrder(TypeOrder typeOrder)
    {
        return new TypeOrderDTO
        {
            Id = typeOrder.Id,
            Name = typeOrder.Name
        };
    }
}
