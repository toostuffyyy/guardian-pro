using System.Text.Json.Serialization;

namespace GuardianProAPI.ModelDTO;

public class EmailDTO
{
    [JsonPropertyName("email1")]
    public string? Email { get; set; }
}