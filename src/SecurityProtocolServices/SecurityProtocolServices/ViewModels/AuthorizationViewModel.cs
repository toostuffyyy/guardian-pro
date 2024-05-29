using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls.Notifications;
using SecurityProtocolServices.Context;
using SecurityProtocolServices.Models;
using Splat;

namespace SecurityProtocolServices.ViewModels;

public class AuthorizationViewModel : ViewModelBase
{
    public string Login { get; set; }
    public string Password { get; set; }
    public string SecretWord { get; set; }
    public List<Post> Posts { get; set; }
    public Post SelectedPost { get; set; }

    public AuthorizationViewModel()
    {
        Posts = DataBaseContext.Context.Posts.ToList();
    }

    public void SingIn()
    {
        if (SelectedPost != null)
        {
            var authorizations = DataBaseContext.Context.AuthorizationGuards
                .FirstOrDefault(a => a.IdNavigation.PostId == SelectedPost.Id && 
                                     a.Login == Login && 
                                     a.Passwod == Password && 
                                     a.SecretWord == SecretWord);
            if (authorizations == null)
            {
                Locator.Current.GetService<INotificationManager>().Show(new Notification("Ошибка", "Авторизация не выполнена", NotificationType.Error));
                return;
            }
            Locator.Current.GetService<INotificationManager>()
                .Show(new Notification("Успех", $"Добро пожаловать!", NotificationType.Success));
            (Owner as MainWindowViewModel).SelectedViewModel = new ManageSecuriryViewModel(authorizations) { Owner = this };
        }
    }
}