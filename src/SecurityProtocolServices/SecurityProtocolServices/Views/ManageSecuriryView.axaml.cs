using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace SecurityProtocolServices.Views;

public partial class ManageSecuriryView : UserControl
{
    public ManageSecuriryView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}