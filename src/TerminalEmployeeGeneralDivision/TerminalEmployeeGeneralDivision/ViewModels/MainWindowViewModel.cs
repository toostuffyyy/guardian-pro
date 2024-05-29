using ReactiveUI;

namespace TerminalEmployeeGeneralDivision.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private ViewModelBase _selectedViewModel;

    public ViewModelBase SelectedViewModel
    {
        get => _selectedViewModel;
        set => this.RaiseAndSetIfChanged(ref _selectedViewModel, value);
    }

    public MainWindowViewModel()
    {
        SelectedViewModel = new AuthorizationViewModel() { Owner = this };
    }
}