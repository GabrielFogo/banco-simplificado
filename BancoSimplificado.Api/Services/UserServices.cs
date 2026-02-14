using BancoSimplificado.Api.DTOs;
using BancoSimplificado.Api.Interfaces.Repositories;
using BancoSimplificado.Api.Interfaces.Services;
using BancoSimplificado.Api.Models;
using System.Security.Claims;

namespace BancoSimplificado.Api.Services;

public class UserServices : IUserService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserServices(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<User> GetUserFromClaims(ClaimsPrincipal claimsPrincipal)
    {
        var email = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
        var user = await _unitOfWork.UserRepository.GetAsync(u => u.Email == email);

        return user!;
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
        var users = await _unitOfWork.UserRepository.GetAllAsync();

        var usersDto = users.Select(user => new UserDto
        {
            Name = user.Name,
            Balance = user.Balance,
            Email = user.Email,
            Role = user.Role
        }).ToList();

        return usersDto;
    }

    public bool CanUserPerformTransaction(User user, decimal amount)
    {
        return user.Role != UserType.Seller && user.Balance >= amount;
    }

    public async Task<decimal> AddBalance(string cpf, decimal amount)
    {
        var user = await _unitOfWork.UserRepository.GetAsync(u => u.Cpf == cpf);
        user!.Balance += amount;

        await _unitOfWork.CommitAsync();

        return user!.Balance;
    }
}