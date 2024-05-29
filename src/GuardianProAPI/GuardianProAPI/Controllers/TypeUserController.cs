using GuardianProAPI.Context;
using GuardianProAPI.Entities;
using GuardianProAPI.ModelsDTO;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GuardianProAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TypeUserController : ControllerBase
{
    // Авторизация по данным из Стражника.
    [HttpPost("AuthorizationEmp")]
    public async Task<ActionResult<AuthorizationGuard>> AuthorizationEmp(AuthorizationEmployeeDTO authorizationEmployeeDto)
    {
        var authorization = await DataBaseContext.Context.AuthorizationGuards
            .Include(a => a.IdNavigation)
            .Include(a => a.IdNavigation.TypeUser)
            .FirstOrDefaultAsync(a => a.Login == authorizationEmployeeDto.Login && a.Passwod == authorizationEmployeeDto.Passwod 
                && a.SecretWord == authorizationEmployeeDto.SecretWord && a.IdNavigation.TypeUser.Name == authorizationEmployeeDto.TypeUser.Name);
        if (authorization == null)
            return Forbid();
        return Ok(AuthorizationEmployeeDTO.CreateByAuthorizationEmployee(authorization));
    }
    // Получение типов пользователей для comboBox.
    [HttpGet("GetUserType")]
    public async Task<ActionResult<List<TypeUserDTO>>> GetUserTypes()
    {
        var typeusers = await DataBaseContext.Context.TypeUsers
            .ToListAsync();
        if (typeusers == null)
            return BadRequest();
        return Ok(typeusers.Select(TypeUserDTO.CreateByTypeUser).ToList());
    }
}