using System;
using System.Collections.Generic;
using GuardianProAPI.Entities;

namespace GuardianProAPI.ModelsDTO;

public partial class OrderDTO
{
    public int Id { get; set; }
    public int EmployeeCode { get; set; }
    public int TypeOrderId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string GoalVisit { get; set; } = null!;
    public string? NameGroup { get; set; }
    public string? RealsonForRefusal { get; set; }
    public string? Purpose { get; set; }
    public StatusDTO Status { get; set; }
    public TypeOrderDTO TypeOrder { get; set; }
    public EmployeeDTO? Employees { get; set; }
    public virtual List<VisitorDTO> Visitors { get; set; }
    public static OrderDTO CreateByOrder(Order order)
    {
        return new OrderDTO
        {
            Id = order.Id,
            EmployeeCode = order.CodeEmployee,
            TypeOrderId = order.TypeOrderId,
            StartDate = order.StartDate,
            EndDate = order.EndDate,
            Status = StatusDTO.CreateByStatus(order.Status),
            TypeOrder = TypeOrderDTO.CreateByTypeOrder(order.TypeOrder),
            Employees = EmployeeDTO.CreateByEmployee(order.CodeEmployeeNavigation),
            GoalVisit = order.GoalVisit,
            NameGroup = order.NameGroup,
            RealsonForRefusal = order.ReasonForRefusal,
            Purpose = order.Purpose,
            Visitors = order.Visitors.Select(a =>
                VisitorDTO.CreateByVisitor(a)).ToList()
        };
    }
}
