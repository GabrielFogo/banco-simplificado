using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace picpay_simplificado.Models;

public class Transaction
{
    [Key]
    public int TransactionId { get; set; }
    
    [ForeignKey("SenderUser")]
    [MaxLength(14)]
    public string? SenderUserCpf { get; set; }
    public User? SenderUser { get; set; }
    
    [MaxLength(14)]
    public string? RecipientUserCpf { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Amount { get; set; }
    
    public DateTime RealeaseDate { get; set; } = DateTime.Now;
}