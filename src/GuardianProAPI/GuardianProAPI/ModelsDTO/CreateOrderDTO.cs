namespace GuardianProAPI.ModelsDTO;

public class CreateOrderDTO
{
    public int EmployeeCode { get; set; }

    public int TypeOrderId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string GoalVisit { get; set; } = null!;
    public IList<VisitorDTO> Visitors { get; set; }

}