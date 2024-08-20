using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace picpay_simplificado.DTOs.Responses;

public record LoginResponse() : Response()
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Token { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime? Expiration { get; set; }
}