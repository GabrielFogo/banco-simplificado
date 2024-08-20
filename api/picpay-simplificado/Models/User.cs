using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace picpay_simplificado.Models;

public class User
{

    public User()
    {
        Transactions = new List<Transaction>();
    }
    
    [Key]
    [Required]
    [MaxLength(14)]
    public string? Cpf { get; init; }
   
    [Required]
    [MaxLength(50)]
    public string? Name { get; init; }
    
    [Column(TypeName = "decimal(10,2)")]
    public decimal Balance { get; set; }
    
    [Required]
    [EnumDataType(typeof(UserType))]
    public UserType Role { get; init; }
    
    [EmailAddress]
    [MaxLength(50)]
    public string? Email { get; init; }
    
    [Required]
    [MaxLength(30)]
    public string? Password { get; init; }
    
    public ICollection<Transaction> Transactions { get; init; }
}