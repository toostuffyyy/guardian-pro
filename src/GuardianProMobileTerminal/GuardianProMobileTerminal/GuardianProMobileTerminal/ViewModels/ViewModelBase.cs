using ReactiveUI;

namespace GuardianProMobileTerminal.ViewModels;

public class ViewModelBase : ReactiveObject
{
    public ViewModelBase Owner { get; set; }
}
