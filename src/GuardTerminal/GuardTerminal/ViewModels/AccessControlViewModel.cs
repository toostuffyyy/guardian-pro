namespace GuardTerminal.ViewModels;

public class AccessControlViewModel : ViewModelBase
{
    public void GoBackView()
    {
        (Owner.Owner as MainWindowViewModel).SelectedViewModel = Owner;
    }
}