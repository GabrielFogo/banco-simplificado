namespace BancoSimplificado.Api.DTOs;

public abstract record Response
{
    public string? Status { get; set; }
    public string? Message { get; set; }
}