using System.ComponentModel.DataAnnotations;

namespace picpay_simplificado.DTOs.Resquests;

public record PerformTransactionRequest()
{
    [Required]
    public string? RecipientUserCpf { get; set; }
    
    [Required]
    public decimal Amount { get; set; }
}