using BancoSimplificado.Api.Models;
using System.ComponentModel.DataAnnotations;

namespace BancoSimplificado.Api.DTOs.Resquests;

public record RegisterRequest
{
    [Key]
    [Required]
    public string? Cpf { get; set; }

    [Required]
    [MaxLength(50)]
    public string? Name { get; set; }

    [Required]
    [EnumDataType(typeof(UserType))]
    public UserType Role { get; set; }

    [EmailAddress]
    [MaxLength(50)]
    public string? Email { get; set; }

    [Required]
    [MaxLength(30)]
    public string? Password { get; set; }

    [Required]
    [MaxLength(30)]
    public string? ConfirmPassword { get; set; }
};