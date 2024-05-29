using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using SecurityProtocolServices.Context;
using SecurityProtocolServices.Models;

namespace SecurityProtocolServices.ViewModels;

public class ManageSecuriryViewModel : ViewModelBase
{
    private List<User> _users;
    private List<User> _mandateUsers;
    public List<TypeUser> TypeUsers { get; set; }
    public AuthorizationGuard User { get; set; }

    public List<User> MandateUsers
    {
        get => _mandateUsers;
        set => this.RaiseAndSetIfChanged(ref _mandateUsers, value);
    }

    public List<User> Users
    {
        get => _users;
        set => this.RaiseAndSetIfChanged(ref _users, value);
    }
    public ManageSecuriryViewModel(AuthorizationGuard user)
    {
        User = user;
        TypeUsers = DataBaseContext.Context.TypeUsers.ToList();
        Users = DataBaseContext.Context.Users
            .Where(a => a.Approved == false)
            .Include(a => a.AuthorizationGuard)
            .ToList();
        MandateUsers = DataBaseContext.Context.Users
            .Where(a => a.IsMandates == false && a.Approved == true)
            .Include(a => a.AuthorizationGuard)
            .ToList();
    }

    public void Approv()
    {
        DataBaseContext.Context.SaveChanges();
        Users = DataBaseContext.Context.Users
            .Where(a => a.Approved == false)
            .Include(a => a.AuthorizationGuard)
            .ToList();
        MandateUsers = DataBaseContext.Context.Users
            .Where(a => a.IsMandates == false && a.Approved == true)
            .Include(a => a.AuthorizationGuard)
            .ToList();
    }

    public void Mandates()
    {
        MandateUsers.ForEach(a =>
        {
            if (a.AddDataRute || a.LookDataRute || a.ReportRute)
                a.IsMandates = true;
        });
        DataBaseContext.Context.SaveChanges();
        Users = DataBaseContext.Context.Users
            .Where(a => a.Approved == false)
            .Include(a => a.AuthorizationGuard)
            .ToList();
        MandateUsers = DataBaseContext.Context.Users
            .Where(a => a.IsMandates == false && a.Approved == true)
            .Include(a => a.AuthorizationGuard)
            .ToList();
    }

    public void GoBack()
    {
        (Owner.Owner as MainWindowViewModel).SelectedViewModel = Owner;
    }
}