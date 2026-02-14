using System.ComponentModel.DataAnnotations;

namespace BancoSimplificado.Api.DTOs.Resquests;

public record LoginResquest()
{
    [Required]
    [EmailAddress(ErrorMessage = "Password is required")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; set; }
}