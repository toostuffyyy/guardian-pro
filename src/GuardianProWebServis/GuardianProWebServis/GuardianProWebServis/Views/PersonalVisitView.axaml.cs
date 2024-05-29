using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace GuardianProWebServis.Views;

public partial class PersonalVisitView : UserControl
{
    public PersonalVisitView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}