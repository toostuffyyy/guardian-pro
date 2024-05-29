using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reactive;
using System.Reactive.Linq;
using GuardianPROWebServis.ModelDTO;
using ReactiveUI;
using Splat;

namespace GuardianPROWebServis.ViewModels;

public class AuthorizationViewModel : ViewModelBase
{
    public LoginPasswordDTO LoginPasswordDTO { get; set; }
    public ReactiveCommand<Unit,Unit> AuthorizationCommand { get; }

    public AuthorizationViewModel()
    {
        AuthorizationCommand = ReactiveCommand.CreateFromObservable(Authorization);
        LoginPasswordDTO = new LoginPasswordDTO();
    }
    public void GoToRegistration()
    {
        (Owner as MainViewModel).SelectedViewModel = new RegistrationViewModel(){Owner = this};
    }

    private async void Auth()
    {
        var response = await Locator.Current.GetService<HttpClient>()
            .PostAsJsonAsync("https://localhost:7010/api/Authorization/Authorization", LoginPasswordDTO);
        
        if (response != null && response.StatusCode == HttpStatusCode.OK)
        {
            AuthorizationDTO authorizationDto = response.Content.ReadFromJsonAsync<AuthorizationDTO>().Result;
            (Owner as MainViewModel).SelectedViewModel = new SelectOrderViewModel(){Owner = this};
        }
    }
    private IObservable<Unit> Authorization()
    {
        return Observable.Start(() =>
        {
            Auth();
        });
    }
}