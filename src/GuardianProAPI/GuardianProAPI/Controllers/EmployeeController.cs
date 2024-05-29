using Azure.Core;
using GuardianProAPI.Context;
using GuardianProAPI.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace GuardianProAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    // Авторизация по коду сотрудника.
    [HttpPost("Authorization")]
    public async Task<ActionResult<EmployeeDTO>> GetCodeEmployee(CodeEmployeeDTO codeEmployeeDto)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        var code = await DataBaseContext.Context.Employees
            .FirstOrDefaultAsync(a => a.Code == codeEmployeeDto.Code);
        if (code == null)
            return Forbid();
        return Ok();
    }
}