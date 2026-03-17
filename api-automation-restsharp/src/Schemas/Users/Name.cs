using System.Text.Json.Serialization;

namespace Schemas;

public class Name
{
    [JsonPropertyName("firstname")]
    public string FirstName { get; set; }

    [JsonPropertyName("lastname")]
    public string LastName { get; set; }

}
