using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace GuardianPROWebServis.Views;

public partial class GroupVisitView : UserControl
{
    public GroupVisitView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}