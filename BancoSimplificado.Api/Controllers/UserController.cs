using BancoSimplificado.Api.DTOs;
using BancoSimplificado.Api.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BancoSimplificado.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }


    [Authorize(Policy = "AdminOnly")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }

    [Authorize(Policy = "AdminOnly")]
    [HttpPost]
    public async Task<ActionResult<decimal>> AddCash(string cpf, decimal amount)
    {
        var saldoAtualizado = await _userService.AddBalance(cpf, amount);
        return saldoAtualizado;
    }


}