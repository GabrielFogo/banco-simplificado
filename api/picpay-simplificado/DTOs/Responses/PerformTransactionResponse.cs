using System.Text.Json.Serialization;

namespace picpay_simplificado.DTOs.Responses;

public record PerformTransactionResponse() : Response
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? RecipientUserCpf { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public decimal? Amount { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime? RealeaseDate { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? SenderUserCpf { get; set; }
}

