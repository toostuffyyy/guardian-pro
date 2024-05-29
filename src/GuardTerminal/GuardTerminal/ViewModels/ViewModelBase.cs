using ReactiveUI;

namespace GuardTerminal.ViewModels;

public class ViewModelBase : ReactiveObject
{
    public ViewModelBase Owner { get; set; }
}