using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace GuardTerminal.Views;

public partial class AccessControlView : UserControl
{
    public AccessControlView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}