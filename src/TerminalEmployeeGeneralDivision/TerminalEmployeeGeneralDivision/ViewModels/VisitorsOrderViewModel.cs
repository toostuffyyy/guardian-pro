using ReactiveUI;
using TerminalEmployeeGeneralDivision.ModelsDTO;

namespace TerminalEmployeeGeneralDivision.ViewModels;

public class VisitorsOrderViewModel : ViewModelBase
{
    public OrderDTO OrderDto { get; set; }
    public VisitorsOrderViewModel(OrderDTO orderDto)
    {
        OrderDto = new OrderDTO();
        OrderDto = orderDto;
    }
}