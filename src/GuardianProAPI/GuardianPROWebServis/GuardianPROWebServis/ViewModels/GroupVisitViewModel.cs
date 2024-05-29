using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reactive;
using System.Reactive.Linq;
using GuardianPROWebServis.ModelDTO;
using ReactiveUI;
using Splat;

namespace GuardianPROWebServis.ViewModels;

public class GroupVisitViewModel : ViewModelBase
{
    public EmployeeDTO SelectedEmployeeDto { get; set; }
    private ObservableAsPropertyHelper<List<EmployeeDTO>> _empl;
    public List<EmployeeDTO> EmployeeDto => _empl.Value;
    public CreateOrderDTO CreateOrderDto { get; set; }
    public VisitorDTO VisitorDto { get; set; }
    public ReactiveCommand<Unit,Unit> OrderCommand { get; }
    public ReactiveCommand<Unit,Unit> DivisionCommand { get; }
    private List<DivisionDTO> _divisionDto;
    private DivisionDTO _selectedDivision;
    public DivisionDTO SelectedDivision
    {
        get => _selectedDivision;
        set => this.RaiseAndSetIfChanged(ref _selectedDivision, value);
    }
    public List<DivisionDTO> DivisionDto
    {
        get => _divisionDto;
        set => this.RaiseAndSetIfChanged(ref _divisionDto, value);
    }
    public GroupVisitViewModel()
    {
        OrderCommand = ReactiveCommand.CreateFromObservable(Order);
        DivisionCommand = ReactiveCommand.CreateFromObservable(Division);
        DivisionCommand.Execute();
        CreateOrderDto = new CreateOrderDTO(){TypeOrderId = 1};
        this.WhenAnyValue(x => x.SelectedDivision)
            .Where(p => p != null)
            .Select(p => p.Employees)
            .ToProperty(this, x => x.EmployeeDto, out _empl);
    }

    private VisitorDTO _selectedVisitor = new VisitorDTO();

    public VisitorDTO SelectedVisitor
    {
        get => _selectedVisitor;
        set => this.RaiseAndSetIfChanged(ref _selectedVisitor, value);
    }

    public void ResetView()
    {
        (Owner.Owner.Owner as MainViewModel).SelectedViewModel = new GroupVisitViewModel() {Owner = this};
    }
    public void AddVisitor()
    {
        CreateOrderDto.Visitors.Add(SelectedVisitor);
        SelectedVisitor = new VisitorDTO();
    }
    private async void DivisionVoid()
    {
        var responce = await Locator.Current.GetService<HttpClient>().GetAsync("https://localhost:7010/api/Division/GetDivision");
        if (responce.StatusCode == HttpStatusCode.OK)
            DivisionDto = responce.Content.ReadFromJsonAsync<List<DivisionDTO>>().Result;
    }

    private async void OrderVoid()
    {
        if (SelectedEmployeeDto != null)
            CreateOrderDto.CodeEmployee = SelectedEmployeeDto.Code;
        var responce = await Locator.Current.GetService<HttpClient>().PostAsJsonAsync("https://localhost:7010/api/Order/AddOrder", CreateOrderDto);
        if (responce.StatusCode == HttpStatusCode.OK)
            CreateOrderDto = responce.Content.ReadFromJsonAsync<CreateOrderDTO>().Result;
    }

    private IObservable<Unit> Order()
    {
        return Observable.Start(() =>
        {
            OrderVoid();
        });
    }
    private IObservable<Unit> Division()
    {
        return Observable.Start(() =>
        {
            DivisionVoid();
        });
    }
}