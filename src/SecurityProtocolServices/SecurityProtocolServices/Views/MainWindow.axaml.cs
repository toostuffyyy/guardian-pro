using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Splat;

namespace SecurityProtocolServices.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        var windowNotificationManager = new WindowNotificationManager(this);
        Locator.CurrentMutable.Register(() => windowNotificationManager, typeof(INotificationManager));
    }
}