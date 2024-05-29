using Avalonia.Animation;
using ReactiveUI;

namespace GuardTerminal.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private ViewModelBase _selectedViewModel;

    public ViewModelBase SelectedViewModel
    {
        get => _selectedViewModel;
        set => this.RaiseAndSetIfChanged(ref _selectedViewModel, value);
    }
    // Конструктор.
    public MainWindowViewModel()
    {
        SelectedViewModel = new AuthorizationViewModel() {Owner = this};
    }
}