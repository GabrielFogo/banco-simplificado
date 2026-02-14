using BancoSimplificado.Api.DTOs.Responses;
using BancoSimplificado.Api.DTOs.Resquests;
using BancoSimplificado.Api.Models;
using System.Security.Claims;

namespace BancoSimplificado.Api.Interfaces.Services;

public interface ITransactionServices
{
    public Task<IEnumerable<Transaction>> GetTransactionAsync(ClaimsPrincipal claimsPrincipal);
    public Task<PerformTransactionResponse> PerformTransactionAsync(ClaimsPrincipal claimsPrincipal, PerformTransactionRequest performTransactionRequest);
}

