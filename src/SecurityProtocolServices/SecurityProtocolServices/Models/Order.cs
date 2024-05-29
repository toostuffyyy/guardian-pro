using System;
using System.Collections.Generic;

namespace SecurityProtocolServices.Models;

public partial class Order
{
    public int Id { get; set; }

    public int CodeEmployee { get; set; }

    public int StatusId { get; set; }

    public int TypeOrderId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string GoalVisit { get; set; } = null!;

    public string? NameGroup { get; set; }

    public string? ReasonForRefusal { get; set; }

    public string? Purpose { get; set; }

    public virtual Employee CodeEmployeeNavigation { get; set; } = null!;

    public virtual ICollection<Document> Documents { get; } = new List<Document>();

    public virtual Status Status { get; set; } = null!;

    public virtual TypeOrder TypeOrder { get; set; } = null!;

    public virtual ICollection<Visitor> Visitors { get; } = new List<Visitor>();
}
