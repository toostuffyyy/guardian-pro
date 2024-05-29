using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace TerminalEmployeeSecurity.Views;

public partial class ListApprovedOrdersView : UserControl
{
    public ListApprovedOrdersView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}