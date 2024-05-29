using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reactive;
using System.Reactive.Linq;
using Avalonia.Threading;
using GuardianPROWebServis.ModelDTO;
using ReactiveUI;
using Splat;

namespace GuardianPROWebServis.ViewModels;

public class RegistrationViewModel : ViewModelBase
{

    public RegestrationDTO Registration { get; set; }
    public ReactiveCommand<Unit,Unit> RegistrationCommand { get; }
   

    public RegistrationViewModel()
    {
        RegistrationCommand = ReactiveCommand.CreateFromObservable(Authorization);
        Registration = new RegestrationDTO();
    }
    public void GoToAuthorization()
    {
        (Owner.Owner as MainViewModel).SelectedViewModel = Owner;
    }

    private async void RegistrationsVoid()
    {
        var response =  await Locator.Current.GetService<HttpClient>().PostAsJsonAsync("https://localhost:7010/api/Authorization/Registration", Registration);
        if (response.StatusCode == HttpStatusCode.OK)
            (Owner.Owner as MainViewModel).SelectedViewModel = new SelectOrderViewModel() { Owner = this };
    }
    private IObservable<Unit> Authorization()
    {
        return Observable.Start(() =>
        {
            RegistrationsVoid();
        });
    }
}