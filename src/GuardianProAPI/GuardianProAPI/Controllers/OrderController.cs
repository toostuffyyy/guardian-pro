using Azure.Core;
using GuardianProAPI.Context;
using GuardianProAPI.Entities;
using GuardianProAPI.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GuardianProAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    // Получение заказов по UserId.
    [HttpPost("GetOrderUser")]
    public async Task<ActionResult<IList<OrderDTO>>> GetOrdersUser(UserIdDTO userIdDto)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        var order = await DataBaseContext.Context.Orders
            .Include(a => a.TypeOrder)
            .Include(a => a.Status)
            .Include(a => a.Visitors)
            .Include(a => a.CodeEmployeeNavigation)
            .Where(p => p.Visitors.Select(a => a.Id).Contains(userIdDto.Id))
            .ToListAsync();
        if (order == null)
            return NotFound();
        return Ok(order.Select(OrderDTO.CreateByOrder).ToList());
    }
    
    // Получение всех заказов.
    [HttpGet("GetApprovedOrders")]
    public async Task<ActionResult<List<OrderDTO>>> GetApprovedOrders()
    {
        var order = await DataBaseContext.Context.Orders
            .Include(a => a.Visitors)
            .Include(a => a.Status)
            .Include(a => a.TypeOrder)
            .Include(a => a.CodeEmployeeNavigation)
            .Include(a => a.CodeEmployeeNavigation.Division)
            .ToListAsync();
        if (order == null)
            return BadRequest();
        return Ok(order.Select(OrderDTO.CreateByOrder).ToList());
    }
    
    // Добавление заявки.
    [HttpPost("AddOrder")]
    public async Task<ActionResult<IList<Order>>> AddOrder(CreateOrderDTO createOrderDto)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        var order = new Order()
        {
            TypeOrderId = createOrderDto.TypeOrderId,
            CodeEmployee = createOrderDto.EmployeeCode,
            StatusId = 2,
            StartDate = createOrderDto.StartDate,
            EndDate = createOrderDto.EndDate,
            GoalVisit = createOrderDto.GoalVisit,
            Visitors = createOrderDto.Visitors.Select(p =>
            {
                var visitor = DataBaseContext.Context.Visitors
                    .FirstOrDefault(a => a.EmailNavigation.Email1 == p.Email);
                return visitor ?? new Visitor()
                {
                    EmailNavigation = DataBaseContext.Context.Emails.FirstOrDefault(a => a.Email1 == p.Email)
                    ?? new Email(){Email1 = p.Email},
                    PassportNumber = p.PassportNumber,
                    PassportSeries = p.PassportSeries,
                    LastName = p.LastName,
                    Name = p.Name,
                    Patronymic = p.Patronymic,
                    PhoneNumber = p.PhoneNumber,
                    Organization = p.Organization,
                    Notes = p.Notes,
                    DateOfBirth = p.DateOfBirth,
                    ImagePath = p.ImagePath
                };
            }).ToList()
        };
        try
        {
            DataBaseContext.Context.Orders.Add(order);
            await DataBaseContext.Context.SaveChangesAsync();
            DataBaseContext.Context.ChangeTracker.Clear();
            return Ok();
        }
        catch (DbUpdateException e)
        {
            ModelState.AddModelError("DBUpdate", e.InnerException.Message);
            return BadRequest(ModelState);
        }
    }
}