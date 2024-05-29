using GuardianProAPI.Context;
using GuardianProAPI.Entities;
using GuardianProAPI.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GuardianProAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AuthorizationController : ControllerBase
{
    // Авторизация.
    [HttpPost("Authorization")]
    public async Task<ActionResult<AuthorizationDTO>> Authorization(LoginPasswordDTO loginPasswordDto)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        var authorization = await DataBaseContext.Context.Authorizations
            .FirstOrDefaultAsync(p => p.Login == loginPasswordDto.Login && p.Password == loginPasswordDto.Password);
        if (authorization == null)
            return Forbid();
        return Ok(AuthorizationDTO.CreateByAuthorization(authorization));
    }
    // Регистрация.
    [HttpPost("Registration")]
    public async Task<ActionResult<Authorization>> Registration(RegistrationDTO registrationDto)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        else if (await DataBaseContext.Context.Authorizations.AnyAsync(p => p.Email == registrationDto.Email))
        {
            ModelState.AddModelError("Email","Пользователь с таким email уже существует.");
            return BadRequest(ModelState);
        }
        else if (await DataBaseContext.Context.Authorizations.AnyAsync(p => p.Login == registrationDto.Login))
        {
            ModelState.AddModelError("Login","Пользователь с таким логином уже существует.");
            return BadRequest(ModelState);
        }
        try
        {
            var authorization = new Authorization()
            {
                EmailNavigation = await DataBaseContext.Context.Emails.FirstOrDefaultAsync(a => a.Email1 == registrationDto.Email)
                    ?? new Email(){Email1 = registrationDto.Email},
                Login = registrationDto.Login,
                Password = registrationDto.Password
            };
            DataBaseContext.Context.Authorizations.Add(authorization);
            await DataBaseContext.Context.SaveChangesAsync();
            return Ok(AuthorizationDTO.CreateByAuthorization(authorization));
        }
        catch (DbUpdateException)
        {
            ModelState.AddModelError("DBUpdate", "Ошибка сохранения данных.");
            return BadRequest(ModelState);
        }
    }
}