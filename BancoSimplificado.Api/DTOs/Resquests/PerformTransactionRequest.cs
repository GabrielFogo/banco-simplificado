using System.ComponentModel.DataAnnotations;

namespace BancoSimplificado.Api.DTOs.Resquests;

public record PerformTransactionRequest()
{
    [Required]
    public string? RecipientUserCpf { get; set; }

    [Required]
    public decimal Amount { get; set; }
}