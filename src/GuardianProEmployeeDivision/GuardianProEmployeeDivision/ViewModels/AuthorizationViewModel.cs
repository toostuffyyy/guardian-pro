using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;
using Splat;
using GuardianProEmployeeDivision.ModelDTO;

namespace GuardianProEmployeeDivision.ViewModels;

public class AuthorizationViewModel : ViewModelBase
{
    public CodeEmployeeDTO CodeEmployeeDto { get; set; }
    public ReactiveCommand<Unit, Unit> AuthorizationCommand { get; }

    public AuthorizationViewModel()
    {
        CodeEmployeeDto = new CodeEmployeeDTO();
        AuthorizationCommand = ReactiveCommand.CreateFromObservable(Authorization);
    }
    
    private IObservable<Unit> Authorization()
    {
        return Observable.Start(() =>
        {
            try
            {
                var responce =  Locator.Current.GetService<HttpClient>()
                    .PostAsJsonAsync("https://localhost:7176/api/Employee/Authorization", CodeEmployeeDto).Result;
                if (responce != null && responce.StatusCode == HttpStatusCode.OK)
                    (Owner as MainWindowViewModel).SelectedViewModel = new ListOrderViewModel() {Owner = this};
            }
            catch (Exception e)
            {
                
            }
        });
    }
}