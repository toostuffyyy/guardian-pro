using System;
using System.Collections.Generic;
using GuardianProAPI.Entities;

namespace GuardianProAPI.ModelsDTO;

public partial class TypeUserDTO
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public static TypeUserDTO CreateByTypeUser(TypeUser typeUser)
    {
        return new TypeUserDTO()
        {
            Id = typeUser.Id,
            Name = typeUser.Name
        };
    }
}
