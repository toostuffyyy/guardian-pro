
using GuardTerminal.ModelsDTO;

namespace GuardTerminal.ModelsDTO;

public class AuthorizationEmployeeDTO
{
    public string Login { get; set; } = null!;
    public string Passwod { get; set; } = null!;
    public string SecretWord { get; set; } = null!;
    public virtual TypeUserDTO TypeUser { get; set; } = new TypeUserDTO();
}