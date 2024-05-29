using ReactiveUI;

namespace SecurityProtocolServices.ViewModels;

public class ViewModelBase : ReactiveObject
{
    public ViewModelBase Owner { get; set; }
}