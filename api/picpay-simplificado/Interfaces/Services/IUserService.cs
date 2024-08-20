using System.Security.Claims;
using picpay_simplificado.DTOs;
using picpay_simplificado.Models;

namespace picpay_simplificado.Interfaces.Services;

public interface IUserService
{
    public Task<User> GetUserFromClaims(ClaimsPrincipal claimsPrincipal);
    public Task<IEnumerable<UserDto>> GetAllUsersAsync();
    public bool CanUserPerformTransaction(User user, decimal amount);
    public Task<decimal> AddBalance(string cpf, decimal amount);
}