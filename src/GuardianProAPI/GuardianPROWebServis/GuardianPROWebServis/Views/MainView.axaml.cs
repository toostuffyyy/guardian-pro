using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Controls.Notifications;

namespace GuardianPROWebServis.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        Notification notification = new Notification("Заголовок", "Сообщение", NotificationType.Error);
        /*
        WindowNotificationManager windowNotificationManager =
            new WindowNotificationManager(this.VisualRoot as TopLevel);
        windowNotificationManager.Show(notification);
        
        this.Show(notification); */
    }

    /*public void Show(INotification notification)
    {
        Show(notification);
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
    }*/

}