using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reactive;
using System.Reactive.Linq;
using System.Runtime.Intrinsics.Arm;
using Avalonia.Controls.Notifications;
using Avalonia.Threading;
using GuardianProAPI.ModelsDTO;
using ReactiveUI;
using Splat;
using Notification = Avalonia.Controls.Notifications.Notification;

namespace GuardianProWebServis.ViewModels;

public class RegistrationViewModel : ViewModelBase
{
    public RegistrationDTO RegistrationDto { get; set; }
    public ReactiveCommand<Unit, Unit> RegistrationCommand { get; }
    // Конструктор.
    public RegistrationViewModel()
    {
        RegistrationCommand = ReactiveCommand.CreateFromObservable(Registration);
        RegistrationDto = new RegistrationDTO();
    }
    // IObservable registration.
    private IObservable<Unit> Registration()
    {
        return Observable.Start(() =>
        {
            var responce = Locator.Current.GetService<HttpClient>().PostAsJsonAsync("https://localhost:7196/api/Authorization/Registration", RegistrationDto).Result;
            if (responce != null && responce.StatusCode == HttpStatusCode.OK)
            {
                Dispatcher.UIThread.InvokeAsync(() =>
                {
                    Locator.Current.GetService<INotificationManager>()
                        .Show(new Notification("Успех", "Регистрация выполнена", NotificationType.Success));
                });
            }
                
        });
    }
    // Взврат на авторизацию.
    public void GoToAuthorization()
    {
        (Owner.Owner as MainViewModel).SelectedViewModel = Owner;
    }
}