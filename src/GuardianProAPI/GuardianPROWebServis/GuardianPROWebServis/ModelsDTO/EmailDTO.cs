using System.Text.Json.Serialization;

namespace GuardianPROWebServis.ModelDTO;

public class EmailDTO
{
    [JsonPropertyName("email1")]
    public string? Email { get; set; }
}