using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reactive;
using System.Reactive.Linq;
using System.Runtime.InteropServices;
using Avalonia.Controls.Notifications;
using Avalonia.Threading;
using GuardianProAPI.Entities;
using GuardianProWebServis.ModelsDTO;
using ReactiveUI;
using Splat;
using Notification = Avalonia.Controls.Notifications.Notification;

namespace GuardianProWebServis.ViewModels;

public class AuthorizationViewModel : ViewModelBase
{
    public LoginPasswordDTO LoginPasswordDto { get; set; }
    public ReactiveCommand<Unit, Unit> AuthorizationCommand { get; }
    // Конструктор.
    public AuthorizationViewModel()
    {
        AuthorizationCommand = ReactiveCommand.CreateFromObservable(Authorization);
        LoginPasswordDto = new LoginPasswordDTO();
    }

    private async void AuthorizationVoid()
    {
        var responce = await Locator.Current.GetService<HttpClient>()
            .PostAsJsonAsync("https://localhost:7196/api/Authorization/Authorization", LoginPasswordDto);
        if (responce != null && responce.StatusCode == HttpStatusCode.OK)
        {
            var authorizationDto = await responce.Content.ReadFromJsonAsync<AuthorizationDTO>();
            Locator.CurrentMutable.Register(() => authorizationDto, typeof(AuthorizationDTO));
            (Owner as MainViewModel).SelectedViewModel = new SelectOrderViewModel() { Owner = this };
        }
        else
        {
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                Locator.Current.GetService<INotificationManager>().Show(new Notification("Ошибка", "Авторизация не выполнена.", NotificationType.Error));
            });
        }
    }

    private IObservable<Unit> Authorization()
    {
        return Observable.Start(() =>
        {
            AuthorizationVoid();
        });
    }
    // Переход на регистрацию.
    public void GoToRegistration()
    {
        (Owner as MainViewModel).SelectedViewModel = new RegistrationViewModel() { Owner = this };
    }
}