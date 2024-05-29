using GuardianProWebServis.ViewModels;

namespace GuardianProWebServis.ViewModels;

public class SelectOrderViewModel : ViewModelBase
{
    // Переход к регистрации.
    public void GoToAuthorization()
    {
        (Owner.Owner as MainViewModel).SelectedViewModel = Owner;
    }
    // Переход к заявкам.
    public void GoToAllOrderUser()
    {
        (Owner.Owner as MainViewModel).SelectedViewModel = new AllOrdersViewModel() { Owner = this };
    }
    // Переход к индивидуальной форме.
    public void GoToPersonalVisit()
    {
        (Owner.Owner as MainViewModel).SelectedViewModel = new PersonalVisitViewModel() { Owner = this };
    }
    // Переход к групповой заявке.
    public void GoToGroupVisit()
    {
        (Owner.Owner as MainViewModel).SelectedViewModel = new GroupVisitViewModel() { Owner = this };
    }
}