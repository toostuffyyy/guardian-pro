using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Splat;

namespace GuardianProMobileTerminal.Views;

public partial class MainView : UserControl, INotificationManager
{
    public MainView()
    {
        InitializeComponent();
        Locator.CurrentMutable.Register(() => this, typeof(INotificationManager));
    }
    public void Show(INotification content)
    {
        Show(content as object);
    }

    /// <inheritdoc/>
    public async void Show(object content)
    {
        var notification = content as INotification;

        var notificationControl = new NotificationCard
        {
            Content = content
        };

        notificationControl.NotificationClosed += (sender, args) =>
        {
            notification?.OnClose?.Invoke();

            NotificationPanel.Children?.Remove(sender as Control);
        };

        notificationControl.PointerPressed += (sender, args) =>
        {
            if (notification != null && notification.OnClick != null)
            {
                notification.OnClick.Invoke();
            }

            (sender as NotificationCard)?.Close();
        };

        NotificationPanel.Children?.Add(notificationControl);
        
        if (notification != null && notification.Expiration == TimeSpan.Zero)
        {
            return;
        }

        await Task.Delay(notification?.Expiration ?? TimeSpan.FromSeconds(5));

        notificationControl.Close();
    }
}