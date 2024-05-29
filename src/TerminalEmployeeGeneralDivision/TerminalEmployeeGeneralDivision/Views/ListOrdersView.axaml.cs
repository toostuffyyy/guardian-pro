using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace TerminalEmployeeGeneralDivision.Views;

public partial class ListOrdersView : UserControl
{
    public ListOrdersView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}