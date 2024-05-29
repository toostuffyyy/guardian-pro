using GuardianProAPI.Context;
using GuardianProAPI.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GuardianProAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TypeOrderController : ControllerBase
{
    [HttpGet("GetTypeOrder")]
    public async Task<ActionResult<List<TypeOrderDTO>>> GetTypeOrder()
    {
        var typeusers = await DataBaseContext.Context.TypeOrders
            .ToListAsync();
        if (typeusers == null)
            return BadRequest();
        return Ok(typeusers.Select(TypeOrderDTO.CreateByTypeOrder).ToList());
    }
}