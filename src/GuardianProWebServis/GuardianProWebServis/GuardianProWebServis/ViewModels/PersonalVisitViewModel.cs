using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reactive;
using System.Reactive.Linq;
using Avalonia.Controls.Notifications;
using Avalonia.Threading;
using GuardianProWebServis.ModelsDTO;
using ReactiveUI;
using Splat;
using Notification = Avalonia.Controls.Notifications.Notification;

namespace GuardianProWebServis.ViewModels;

public class PersonalVisitViewModel : ViewModelBase
{
    public List<EmployeeDTO> EmployeeDto => _listEmployee.Value;
    private ObservableAsPropertyHelper<List<EmployeeDTO>> _listEmployee;
    private List<DivisionDTO> _divisionDto;
    private DivisionDTO _selectedDivision;
    // Команды.
    public ReactiveCommand<Unit, Unit> OrderCommand { get; }
    public ReactiveCommand<Unit, Unit> DivisionCommand { get; }
    // Свойство для получения кода выбраного работника.
    public EmployeeDTO SelectedEmployee { get; set; }
    // Свойство CreateOrderDto.
    public CreateOrderDTO CreateOrderDto { get; set; }
    // Свойство для получения division.
    public DivisionDTO SelectedDivision
    {
        get => _selectedDivision;
        set => this.RaiseAndSetIfChanged(ref _selectedDivision, value);
    }
    // Свойство List<DivisionDTO>.
    public List<DivisionDTO> DivisionDto
    {
        get => _divisionDto;
        set => this.RaiseAndSetIfChanged(ref _divisionDto, value);
    }
    // Конструктор.
    public PersonalVisitViewModel()
    {
        OrderCommand = ReactiveCommand.CreateFromObservable(CreateOrder);
        DivisionCommand = ReactiveCommand.CreateFromObservable(Division);
        DivisionCommand.Execute();
        CreateOrderDto = new CreateOrderDTO() { TypeOrderId = 1 };
        CreateOrderDto.Visitors.Add(new VisitorDTO());
        this.WhenAnyValue(a => a.SelectedDivision)
            .Where(a => a != null)
            .Select(a => a.Employees)
            .ToProperty(this, a => a.EmployeeDto, out _listEmployee);
    }
    // Void CreateOrderDTO.
    public async void AddOrderDTOVoid()
    {
        if (SelectedEmployee != null)
            CreateOrderDto.EmployeeCode = SelectedEmployee.Code;
        var responce = await Locator.Current.GetService<HttpClient>()
            .PostAsJsonAsync("https://localhost:7196/api/Order/AddOrder", CreateOrderDto);
        if (responce != null && responce.StatusCode == HttpStatusCode.OK)
        {
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                Locator.Current.GetService<INotificationManager>().Show(new Notification("Заявка", "Заявка оформлена", NotificationType.Success));
            });
        }
        else
        {
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                Locator.Current.GetService<INotificationManager>().Show(new Notification("Ошибка", "Заявка не оформлена.", NotificationType.Error));
            });
        }
    }
    // Void List<DivisionDTO>.
    public async void DivisionDTO()
    {
        var responce = await Locator.Current.GetService<HttpClient>()
            .GetAsync("https://localhost:7196/api/Division/GetDivisions");
        if (responce != null && responce.StatusCode == HttpStatusCode.OK)
            DivisionDto = await responce.Content.ReadFromJsonAsync<List<DivisionDTO>>();
    }
    // Observable Order.
    private IObservable<Unit> CreateOrder()
    {
        return Observable.Start(() =>
        {
            AddOrderDTOVoid();
        });
    }
    // Observable Division.
    private IObservable<Unit> Division()
    {
        return Observable.Start(() =>
        {
            DivisionDTO();
        });
    }
    // Метод для выхода.
    public void GoToBack()
    {
        (Owner.Owner.Owner as MainViewModel).SelectedViewModel = Owner;
    }
}