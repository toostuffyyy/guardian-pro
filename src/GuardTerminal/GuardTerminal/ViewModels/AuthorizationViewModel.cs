using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reactive;
using System.Reactive.Linq;
using GuardTerminal.ModelsDTO;
using ReactiveUI;
using Splat;

namespace GuardTerminal.ViewModels;

public class AuthorizationViewModel : ViewModelBase
{
    public AuthorizationEmployeeDTO AuthorizationEmployeeDto { get; set; }
    private TypeUserDTO _selectedTypeUser;
    private List<TypeUserDTO> _typeUserDto;
    public List<TypeUserDTO> TypeUserDto 
    { 
        get => _typeUserDto; 
        set => this.RaiseAndSetIfChanged(ref _typeUserDto, value); 
    }
    public ReactiveCommand<Unit, Unit> AuthorizationCommand { get; }
    public ReactiveCommand<Unit, Unit> GetTypeUSerCommand { get; }

    public TypeUserDTO SelectedTypeUser
    {
        get => _selectedTypeUser;
        set => this.RaiseAndSetIfChanged(ref _selectedTypeUser, value);
    }
    // Конструтор.
    public AuthorizationViewModel()
    {
        AuthorizationEmployeeDto = new AuthorizationEmployeeDTO();
        GetTypeUSerCommand = ReactiveCommand.CreateFromObservable(GetTypeUser);
        GetTypeUSerCommand.Execute();
        AuthorizationCommand = ReactiveCommand.CreateFromObservable(Authorization);
    }
    private IObservable<Unit> Authorization()
    {
        return Observable.Start(() =>
        {
            if (SelectedTypeUser != null)
                AuthorizationEmployeeDto.TypeUser.Name = SelectedTypeUser.Name;
            var responce = Locator.Current.GetService<HttpClient>()
                .PostAsJsonAsync("https://localhost:7196/api/TypeUser/AuthorizationEmp", AuthorizationEmployeeDto).Result;
            if (responce != null && responce.StatusCode == HttpStatusCode.OK)
                (Owner as MainWindowViewModel).SelectedViewModel = new AccessControlViewModel() { Owner = this };
        });
    }
    private IObservable<Unit> GetTypeUser()
    {
        return Observable.Start(() =>
        {
            var responce = Locator.Current.GetService<HttpClient>()
                .GetAsync("https://localhost:7196/api/TypeUser/GetUserType").Result;
            if (responce != null && responce.StatusCode == HttpStatusCode.OK)
                TypeUserDto = responce.Content.ReadFromJsonAsync<List<TypeUserDTO>>().Result;
        });
    }
}