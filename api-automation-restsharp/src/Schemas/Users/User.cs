using System.Text.Json.Serialization;

namespace Schemas;

public class User
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("username")]
    public string Username { get; set; }

    [JsonPropertyName("password")]
    public string Password { get; set; }

    [JsonPropertyName("name")]
    public Name Name { get; set; }

    [JsonPropertyName("phone")]
    public string Phone { get; set; }
}