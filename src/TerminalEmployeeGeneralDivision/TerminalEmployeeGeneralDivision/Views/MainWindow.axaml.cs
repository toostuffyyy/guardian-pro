using Avalonia.Controls;
using Avalonia.Controls.Notifications;

namespace TerminalEmployeeGeneralDivision.Views;

public partial class MainWindow : Window, INotificationManager
{
    public MainWindow()
    {
        InitializeComponent();
        
    }

    public void Show(INotification notification)
    {
        throw new System.NotImplementedException();
    }
}