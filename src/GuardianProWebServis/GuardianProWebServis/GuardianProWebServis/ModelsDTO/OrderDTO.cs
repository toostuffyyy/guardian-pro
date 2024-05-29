using System;
using System.Collections.Generic;
using GuardianProAPI.Entities;

namespace GuardianProWebServis.ModelsDTO;

public partial class OrderDTO
{
    public int Id { get; set; }
    public int EmployeeCode { get; set; }
    public int TypeOrderId { get; set; }
    public int StatusId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set;}
    public string GoalVisit { get; set; } = null!;
    public string? NameGroup { get; set; }
    public string? RealsonForRefusal { get; set; }
    public string? Purpose { get; set; }
    public StatusDTO Status { get; set; }
    
    public EmployeeDTO Employees { get; set; }
    public TypeOrderDTO TypeOrder { get; set; }
    public virtual List<VisitorDTO> Visitors { get; set; }
}
