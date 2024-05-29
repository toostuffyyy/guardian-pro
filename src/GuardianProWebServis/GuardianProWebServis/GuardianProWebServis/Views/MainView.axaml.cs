using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Splat;

namespace GuardianProWebServis.Views;

public partial class MainView : UserControl, INotificationManager
{
    public MainView()
    {
        InitializeComponent();
        Locator.CurrentMutable.Register(() => this, typeof(INotificationManager));
    }
    // Система уведомлений.
    public void Show(INotification notification)
    {
        Show(notification as object);
    }
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