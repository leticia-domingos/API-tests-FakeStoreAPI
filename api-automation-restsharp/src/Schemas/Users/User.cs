using System.Text.Json.Serialization;

namespace Schemas;

public class User
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("email")]
    public required string Email { get; set; }

    [JsonPropertyName("username")]
    public required string Username { get; set; }

    [JsonPropertyName("password")]
    public required string Password { get; set; }

    [JsonPropertyName("name")]
    public required Name Name { get; set; }

    [JsonPropertyName("phone")]
    public required string Phone { get; set; }
}