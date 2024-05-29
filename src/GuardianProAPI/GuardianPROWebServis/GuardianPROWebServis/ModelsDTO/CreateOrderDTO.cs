using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;

namespace GuardianPROWebServis.ModelDTO;

public class CreateOrderDTO
{
    public int CodeEmployee { get; set; }
    public int TypeOrderId { get; set; }
    public int StatusId { get; set; }
    public DateTime StartDate { get; set; } = DateTime.Now;
    public DateTime EndDate { get; set; }= DateTime.Now.AddDays(1);
    public string GoalVisit { get; set; } = null!;
    public ObservableCollection<VisitorDTO> Visitors { get; set; } = new ObservableCollection<VisitorDTO>();
    public IList<DocumentDTO> Documents { get; set; } = new List<DocumentDTO>();
}