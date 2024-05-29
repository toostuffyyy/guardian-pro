using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace GuardTerminal.Views;

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