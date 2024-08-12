using System.ComponentModel.DataAnnotations;

namespace picpay_simplificado.DTOs;

public record LoginDto
{
    [Required]
    [EmailAddress(ErrorMessage = "Password is required")]
    public string? Email { get; set; }
    
    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; set; }
};