using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace picpay_simplificado.Models;

public class Transaction
{
    [Key]
    public int TransactionId { get; init; }
    
    [MaxLength(14)]
    public string? RecipientUserCpf { get; init; }
    
    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Amount { get; init; }
    
    public DateTime RealeaseDate { get; init; } = DateTime.Now;
    
    [ForeignKey("SenderUser")]
    [MaxLength(14)]
    public string? SenderUserCpf { get; init; }
    
    public User? SenderUser { get; init; }
}