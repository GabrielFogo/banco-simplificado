namespace picpay_simplificado.DTOs;

public abstract record Response
{
    public string? Status { get; set; }
    public string? Message { get; set; }
}