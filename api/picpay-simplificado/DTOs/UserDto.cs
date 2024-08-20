using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using picpay_simplificado.Models;

namespace picpay_simplificado.DTOs;

public class UserDto
{
    public string? Name { get; set; }
    
    [Column(TypeName = "decimal(10,2)")]
    public decimal Balance { get; set; }
    
    [Required]
    [EnumDataType(typeof(UserType))]
    public UserType Role { get; set; }
    
    [EmailAddress]
    [MaxLength(50)]
    public string? Email { get; set; }
}