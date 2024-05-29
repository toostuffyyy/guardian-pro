using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reactive;
using System.Reactive.Linq;
using Avalonia.Controls;
using GuardianPROWebServis.ModelDTO;
using ReactiveUI;
using Splat;

namespace GuardianPROWebServis.ViewModels;

public class AllOrdersViewModel : ViewModelBase
{
    private List<OrderDTO> _orderDto;
    public ReactiveCommand<Unit, Unit> GetOrderCommand;

    public AllOrdersViewModel()
    {
        GetOrderCommand = ReactiveCommand.CreateFromObservable(GetOrder);
        GetOrderCommand.Execute();
    }

    public List<OrderDTO> OrderDto
    {
        get => _orderDto;
        set => this.RaiseAndSetIfChanged(ref _orderDto, value);
    }

    public async void GetOrdes()
    {
        var responce = await Locator.Current.GetService<HttpClient>()
            .GetAsync("https://localhost:7010/api/Order/GetOrders");
        if (responce.StatusCode == HttpStatusCode.OK)
            OrderDto = responce.Content.ReadFromJsonAsync<List<OrderDTO>>().Result;
    }

    private IObservable<Unit> GetOrder()
    {
        return Observable.Start(() =>
        {
            GetOrdes();
        });
    }
}