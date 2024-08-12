using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using picpay_simplificado.DTOs;
using picpay_simplificado.Interfaces.Repositories;
using picpay_simplificado.Interfaces.Services;
using picpay_simplificado.Models;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace picpay_simplificado.Controllers;

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
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        var userExists = await _unitOfWork.UserRepository.GetAsync(user => user.Name == registerDto.Name);

        if (userExists is not null)
            return StatusCode(StatusCodes.Status500InternalServerError,
                new Response()
                {
                    Status = "Error",
                    Message = "Usuario já existe"
                });

        var user = new User()
        {
            Cpf = registerDto.Cpf,
            Name = registerDto.Name,
            Email = registerDto.Email,
            Password = registerDto.Password,
            Role = registerDto.Role
        };

        _unitOfWork.UserRepository.Create(user);
        await _unitOfWork.CommitAsync();

        return Ok(new Response() { Status = "Success", Message = "Usuario criado com sucesso" });
    }
   
    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        
        var user = await _unitOfWork.UserRepository.GetAsync(user => user.Email == loginDto.Email);

        if (user is null)
            return StatusCode(StatusCodes.Status401Unauthorized, 
                new Response(){ Status = "Error", Message = "User not exist" });

        if (user.Password != loginDto.Password)
            return StatusCode(StatusCodes.Status401Unauthorized, 
                new Response(){ Status = "Error", Message = "Incorrect email or password" });

        var authClaims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, user.Name!),
            new Claim(ClaimTypes.Role, user.Role.ToString()!),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = _tokenService.GenerateAcessToken(authClaims, _configuration);
        
        return Ok(new
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Expiration = token.ValidTo,
        });
        
    }
    
}