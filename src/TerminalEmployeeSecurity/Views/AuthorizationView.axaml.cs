using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace TerminalEmployeeGeneralDepartament.Views;

public partial class AuthorizationView : UserControl
{
    public AuthorizationView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}