using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reactive;
using System.Reactive.Linq;
using Avalonia.Controls.Notifications;
using Avalonia.Threading;
using ReactiveUI;
using Splat;
using TerminalEmployeeGeneralDivision.ModelDTO;
using Notification = Avalonia.Controls.Notifications.Notification;

namespace GuardianProMobileTerminal.ViewModels;

public class AuthorizationViewModel : ViewModelBase
{
    public CodeEmployeeDTO CodeEmployeeDto { get; set; }
    public ReactiveCommand<Unit, Unit> AuthorizationCommand { get; }

    public AuthorizationViewModel()
    {
        AuthorizationCommand = ReactiveCommand.CreateFromObservable(Authorization);
        CodeEmployeeDto = new CodeEmployeeDTO();
    }
    
    private IObservable<Unit> Authorization()
    {
        return Observable.FromAsync(async () =>
        {
            var response = await Locator.Current.GetService<HttpClient>()
                .PostAsJsonAsync("https://localhost:7176/api/Employee/Authorization", CodeEmployeeDto);
            response.EnsureSuccessStatusCode();
        })
        .Do(_ =>
        {
            // Handle a successful response
            (Owner as MainViewModel).SelectedViewModel = new AuthorizationViewModel() { Owner = this };
        })
        .Catch((Exception ex) =>
        {
            // Handle an error response
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                Locator.Current.GetService<INotificationManager>()
                    .Show(new Notification("Error", ex.Message, NotificationType.Error));
            });
            return Observable.Empty<Unit>();
        });
    }
}