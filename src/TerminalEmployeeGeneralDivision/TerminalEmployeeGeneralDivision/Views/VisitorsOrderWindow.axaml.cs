using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace TerminalEmployeeGeneralDivision.Views;

public partial class VisitorsOrderWindow : Window
{
    public VisitorsOrderWindow()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}