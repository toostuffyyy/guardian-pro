using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GuardianProWebServis.ModelsDTO;

public class CreateOrderDTO
{
    public int EmployeeCode { get; set; }

    public int TypeOrderId { get; set; }

    public DateTime StartDate { get; set; } = DateTime.Now;

    public DateTime EndDate { get; set; } = DateTime.Now.AddDays(1);

    public string GoalVisit { get; set; } = null!;
    public ObservableCollection<VisitorDTO> Visitors { get; set; } = new ObservableCollection<VisitorDTO>();

}