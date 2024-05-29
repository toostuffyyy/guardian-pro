using ReactiveUI;

namespace GuardianProWebServis.ViewModels;

public class ViewModelBase : ReactiveObject
{
    public ViewModelBase Owner { get; set; }
}