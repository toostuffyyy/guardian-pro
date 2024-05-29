using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;
using Splat;
using TerminalEmployeeGeneralDivision.ModelDTO;

namespace TerminalEmployeeGeneralDivision.ViewModels;

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
            var responce =  Locator.Current.GetService<HttpClient>()
                .PostAsJsonAsync("https://localhost:7196/api/Employee/Authorization", CodeEmployeeDto).Result;
            if (responce != null && responce.StatusCode == HttpStatusCode.OK)
                (Owner as MainWindowViewModel).SelectedViewModel = new ListOrdersViewModel() {Owner = this};
        });
    }
}