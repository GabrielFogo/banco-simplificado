using BancoSimplificado.Api.DTOs;
using BancoSimplificado.Api.Models;
using System.Security.Claims;

namespace BancoSimplificado.Api.Interfaces.Services;

public interface IUserService
{
    public Task<User> GetUserFromClaims(ClaimsPrincipal claimsPrincipal);
    public Task<IEnumerable<UserDto>> GetAllUsersAsync();
    public bool CanUserPerformTransaction(User user, decimal amount);
    public Task<decimal> AddBalance(string cpf, decimal amount);
}