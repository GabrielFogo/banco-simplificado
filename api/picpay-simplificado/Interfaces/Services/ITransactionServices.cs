using System.Security.Claims;
using picpay_simplificado.DTOs;
using picpay_simplificado.DTOs.Responses;
using picpay_simplificado.DTOs.Resquests;
using picpay_simplificado.Models;

namespace picpay_simplificado.Interfaces;

public interface ITransactionServices
{
    public Task<IEnumerable<Transaction>> GetTransactionAsync(ClaimsPrincipal claimsPrincipal);
    public Task<PerformTransactionResponse> PerformTransactionAsync(ClaimsPrincipal claimsPrincipal, PerformTransactionRequest performTransactionRequest);
}

