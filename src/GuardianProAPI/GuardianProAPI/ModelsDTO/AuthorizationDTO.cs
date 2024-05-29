using System;
using System.Collections.Generic;
using GuardianProAPI.Context;
using GuardianProAPI.Entities;
using GuardianProAPI.ModelsDTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GuardianProAPI.ModelsDTO;

public partial class AuthorizationDTO
{
    public int Id { get; set; }

    public string Email { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;
    public UserEmailDTO? UserEmail { get; set; }
    public static AuthorizationDTO CreateByAuthorization(Authorization authorization)
    {
        return new AuthorizationDTO()
        {
            Id = authorization.Id,
            Email = authorization.Email,
            Login = authorization.Login,
            Password = authorization.Password,
            UserEmail = new UserEmailDTO(){Email = authorization.Email}
        };
    }

}
