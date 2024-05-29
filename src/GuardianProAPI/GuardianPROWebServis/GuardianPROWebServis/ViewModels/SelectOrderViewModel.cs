using System.Reactive;
using ReactiveUI;

namespace GuardianPROWebServis.ViewModels;

public class SelectOrderViewModel : ViewModelBase
{
    public void GoToAllOrders()
    {
        (Owner.Owner as MainViewModel).SelectedViewModel = new AllOrdersViewModel() { Owner = this };
    }
    
    public void GoToAuthorization()
    {
        (Owner.Owner as MainViewModel).SelectedViewModel = Owner;
    }
    public void GoToPersonalVisit()
    {
        (Owner.Owner as MainViewModel).SelectedViewModel = new PersonalVisitViewModel(){Owner = this};
    }public void GoToGroupVisit()
    {
        (Owner.Owner as MainViewModel).SelectedViewModel = new GroupVisitViewModel(){Owner = this};
    }
}