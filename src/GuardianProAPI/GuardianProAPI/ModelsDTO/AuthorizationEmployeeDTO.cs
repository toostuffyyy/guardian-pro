using GuardianProAPI.Entities;

namespace GuardianProAPI.ModelsDTO;

public class AuthorizationEmployeeDTO
{
    public string Login { get; set; } = null!;
    public string Passwod { get; set; } = null!;
    public string SecretWord { get; set; } = null!;
    public virtual TypeUserDTO TypeUser { get; set; }
    public static AuthorizationEmployeeDTO CreateByAuthorizationEmployee(AuthorizationGuard authorizationGuard)
    {
        return new AuthorizationEmployeeDTO()
        {
            Login = authorizationGuard.Login,
            Passwod = authorizationGuard.Passwod,
            SecretWord = authorizationGuard.SecretWord,
            TypeUser = TypeUserDTO.CreateByTypeUser(authorizationGuard.IdNavigation.TypeUser)
        };
    }
}