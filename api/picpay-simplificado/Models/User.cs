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
    public string? Cpf { get; set; }
   
    [Required]
    [MaxLength(50)]
    public string? Name { get; set; }
    
    [Column(TypeName = "decimal(10,2)")]
    public decimal Balance { get; set; }
    
    [Required]
    [EnumDataType(typeof(UserType))]
    public UserType Role { get; set; }
    
    [EmailAddress]
    [MaxLength(50)]
    public string? Email { get; set; }
    
    [Required]
    [MaxLength(30)]
    public string? Password { get; set; }
    
    public ICollection<Transaction> Transactions { get; set; }
}