using ReactiveUI;

namespace GuardianProEmployeeDivision.ViewModels;

public class ViewModelBase : ReactiveObject
{
    
    public ViewModelBase Owner { get; set; }
}