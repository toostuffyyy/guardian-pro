using System;
using System.Collections.Generic;
using Document = System.Reflection.Metadata.Document;

namespace GuardianProEmployeeDivision.ModelsDTO;

public partial class OrderDTO
{
    public int Id { get; set; }

    public int StatusId { get; set; }

    public int EmployeeCode { get; set; }

    public int TypeOrderId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string GoalVisit { get; set; } = null!;

    public string? NameGroup { get; set; }

    public string? RealsonForRefusal { get; set; }

    public string? Purpose { get; set; }

    public virtual EmployeeDTO EmployeeCodeNavigation { get; set; } = null!;

    public virtual StatusDTO Status { get; set; } = null!;

    public virtual TypeOrderDTO TypeOrder { get; set; } = null!;

    public virtual List<VisitorDTO> Visitors { get; set; } = new List<VisitorDTO>();
}
