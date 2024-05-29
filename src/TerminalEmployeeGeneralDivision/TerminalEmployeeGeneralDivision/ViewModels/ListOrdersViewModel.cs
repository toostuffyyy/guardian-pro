using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;
using Splat;
using TerminalEmployeeGeneralDivision.ModelsDTO;
using TerminalEmployeeGeneralDivision.Views;

namespace TerminalEmployeeGeneralDivision.ViewModels;

public class ListOrdersViewModel : ViewModelBase
{
    private TypeOrderDTO _selectedType;
    public TypeOrderDTO SelectedType
    {
        get => _selectedType;
        set => this.RaiseAndSetIfChanged(ref _selectedType, value);
    }
    private List<TypeOrderDTO> _typeOrder;
    public List<TypeOrderDTO> TypeOrder
    {
        get => _typeOrder;
        set => this.RaiseAndSetIfChanged(ref _typeOrder, value);
    }
    // Order.
    private ObservableCollection<OrderDTO> _orderDto;
    public ReactiveCommand<Unit, Unit> GetDataCommand { get; }
    // Свойство Order.
    public ObservableCollection<OrderDTO> OrderDto
    {
        get => _orderDto;
        set => this.RaiseAndSetIfChanged(ref _orderDto, value);
    }
    // Конструктор.
    public ListOrdersViewModel()
    {
        OrderDto = new ObservableCollection<OrderDTO>();
        GetDataCommand = ReactiveCommand.CreateFromObservable(GetData);
        GetDataCommand.Execute();
    }
    // Observable Order.
    private IObservable<Unit> GetData()
    {
        return Observable.Start(() =>
        {
            var responce = Locator.Current.GetService<HttpClient>().GetAsync("https://localhost:7196/api/Order/GetApprovedOrders").Result;
            if (responce.StatusCode == HttpStatusCode.OK)
                OrderDto = responce.Content.ReadFromJsonAsync<ObservableCollection<OrderDTO>>().Result;
            
            responce = Locator.Current.GetService<HttpClient>().GetAsync("https://localhost:7196/api/TypeOrder/GetTypeOrder").Result;
            if (responce.StatusCode == HttpStatusCode.OK)
                TypeOrder = responce.Content.ReadFromJsonAsync<List<TypeOrderDTO>>().Result;
        });
    }

    public void GetVisitorsInfo(OrderDTO orderDto)
    {
        VisitorsOrderWindow visitorsOrderWindow = new VisitorsOrderWindow()
        {
            DataContext = new VisitorsOrderViewModel(orderDto)
        };
        visitorsOrderWindow.Show();
    }
}