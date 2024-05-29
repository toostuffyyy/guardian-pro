using ReactiveUI;

namespace TerminalEmployeeGeneralDivision.ViewModels;

public class ViewModelBase : ReactiveObject
{
    public ViewModelBase Owner { get; set; }
}