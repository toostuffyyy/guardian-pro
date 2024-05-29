using Azure.Core;
using GuardianProAPI.Context;
using GuardianProAPI.Entities;
using GuardianProAPI.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GuardianProAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class DivisionController : ControllerBase
{
    // Получение подразделений.
    [HttpGet("GetDivisions")]
    public async Task<ActionResult<IList<DivisionDTO>>> GetDivisions()
    {
        if (!ModelState.IsValid)
            return BadRequest();
        var division = await DataBaseContext.Context.Divisions
            .Include(a => a.Employees)
            .ToListAsync();
        return Ok(division.Select(DivisionDTO.CreateByDivision).ToList());
    }
}