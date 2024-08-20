using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using picpay_simplificado.DTOs;
using picpay_simplificado.Interfaces.Services;
using picpay_simplificado.Models;

namespace picpay_simplificado.Controllers;

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