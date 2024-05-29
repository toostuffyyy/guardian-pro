using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reactive;
using System.Reactive.Linq;
using GuardianProWebServis.ModelsDTO;
using ReactiveUI;
using Splat;

namespace GuardianProWebServis.ViewModels;

public class AllOrdersViewModel : ViewModelBase
{
    private UserIdDTO _userIdDto;
    private ObservableCollection<OrderDTO> _orderDto;
    public AuthorizationDTO AuthorizationDto;
    // Команда для получения списка заявок посетителя.
    public ReactiveCommand<Unit, Unit> GetUserOrderCommand { get; }
    // Свойство UserEmailDto.
    public UserIdDTO UserIdDto
    {
        get => _userIdDto;
        set => this.RaiseAndSetIfChanged(ref _userIdDto, value);
    }
    // Свойство OrderDTO.
    public ObservableCollection<OrderDTO> OrderDto
    {
        get => _orderDto;
        set => this.RaiseAndSetIfChanged(ref _orderDto, value);
    }
    // Конструктор.
    public AllOrdersViewModel()
    {
        UserIdDto = new UserIdDTO();
        UserIdDto.Id = Locator.Current.GetService<AuthorizationDTO>().Id;
        GetUserOrderCommand = ReactiveCommand.CreateFromObservable(GetUserEmail);
        GetUserOrderCommand.Execute();
    }
    // Void реализация.
    public async void GetUserEmailVoid()
    {
        var responce = await Locator.Current.GetService<HttpClient>()
            .PostAsJsonAsync("https://localhost:7196/api/Order/GetOrderUser", UserIdDto);
        if (responce != null && responce.StatusCode == HttpStatusCode.OK)
            OrderDto = await responce.Content.ReadFromJsonAsync<ObservableCollection<OrderDTO>>();
    }
    // Observeble.
    private IObservable<Unit> GetUserEmail()
    {
        return Observable.Start(() =>
        {
            GetUserEmailVoid();
        });
    }
    // Вернуться.
    public void GoBack()
    {
        (Owner.Owner.Owner as MainViewModel).SelectedViewModel = Owner;
    }
}