namespace GuardianProAPI.ModelsDTO;

public class RegistrationDTO
{
    public string Email { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;
}