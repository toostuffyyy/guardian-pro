using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;
using Splat;
using TerminalEmployeeGeneralDivision.ModelsDTO;

namespace GuardianProMobileTerminal.ViewModels;

public class ListOrderViewModel : ViewModelBase
{
    private ObservableCollection<OrderDTO> _orderDto;
    public ReactiveCommand<Unit, Unit> GetOrdersCommand { get; }
    public ReactiveCommand<Unit, Unit> NotificationCommand { get; }
    // Свойство Order.
    public ObservableCollection<OrderDTO> OrderDto
    {
        get => _orderDto;
        set => this.RaiseAndSetIfChanged(ref _orderDto, value);
    }
    // Конструктор.
    public ListOrderViewModel()
    {
        GetOrdersCommand = ReactiveCommand.CreateFromObservable(GetOrders);
        GetOrdersCommand.Execute();
        OrderDto = new ObservableCollection<OrderDTO>();
    }
    // Observable Order.
    private IObservable<Unit> GetOrders()
    {
        return Observable.Start(() =>
        {
            var responce = Locator.Current.GetService<HttpClient>().GetAsync("https://localhost:7176/api/Order/GetApprovedOrders").Result;
            if (responce.StatusCode == HttpStatusCode.OK)
                OrderDto = responce.Content.ReadFromJsonAsync<ObservableCollection<OrderDTO>>().Result;
        });
    }
}