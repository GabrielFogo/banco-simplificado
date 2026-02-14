using BancoSimplificado.Api.DTOs.Responses;
using BancoSimplificado.Api.DTOs.Resquests;
using BancoSimplificado.Api.Interfaces.Repositories;
using BancoSimplificado.Api.Interfaces.Services;
using BancoSimplificado.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BancoSimplificado.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITokenService _tokenService;
    private readonly IConfiguration _configuration;

    public AuthController(IUnitOfWork unitOfWork, ITokenService tokenService, IConfiguration configuration)
    {
        _unitOfWork = unitOfWork;
        _tokenService = tokenService;
        _configuration = configuration;
    }

    [HttpPost]
    [Route("Register")]
    public async Task<ActionResult<RegisterResponse>> Register([FromBody] RegisterRequest registerRequest)
    {
        var userExists = await _unitOfWork.UserRepository.GetAsync(user => user.Cpf == registerRequest.Cpf);

        if (userExists is not null)
            return StatusCode(StatusCodes.Status500InternalServerError,
                new RegisterResponse()
                {
                    Status = "Error",
                    Message = "Usuario já existe"
                });

        var user = new User()
        {
            Cpf = registerRequest.Cpf,
            Name = registerRequest.Name,
            Email = registerRequest.Email,
            Password = registerRequest.Password,
            Role = registerRequest.Role
        };

        _unitOfWork.UserRepository.Create(user);
        await _unitOfWork.CommitAsync();

        return Ok(new RegisterResponse() { Status = "Success", Message = "Usuario criado com sucesso" });
    }

    [HttpPost]
    [Route("Login")]
    public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginResquest loginRequest)
    {

        var user = await _unitOfWork.UserRepository.GetAsync(user => user.Email == loginRequest.Email);

        if (user is null)
            return StatusCode(StatusCodes.Status401Unauthorized,
                new LoginResponse() { Status = "Error", Message = "User not exist" });

        if (user.Password != loginRequest.Password)
            return StatusCode(StatusCodes.Status401Unauthorized,
                new LoginResponse() { Status = "Error", Message = "Incorrect email or password" });

        var authClaims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, user.Name!),
            new Claim(ClaimTypes.Role, user.Role.ToString()!),
            new Claim(ClaimTypes.Email, user.Email!),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = _tokenService.GenerateAcessToken(authClaims, _configuration);

        return Ok(new LoginResponse()
        {
            Status = "Success",
            Message = "Logado com sucesso",
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Expiration = token.ValidTo,
        });

    }

}