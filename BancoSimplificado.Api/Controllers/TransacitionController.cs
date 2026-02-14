using BancoSimplificado.Api.DTOs.Responses;
using BancoSimplificado.Api.DTOs.Resquests;
using BancoSimplificado.Api.Interfaces.Repositories;
using BancoSimplificado.Api.Interfaces.Services;
using BancoSimplificado.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BancoSimplificado.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class TransacitionController : ControllerBase
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly ITransactionServices _transactionServices;

    public TransacitionController(IUnitOfWork unitOfWork, ITransactionServices transactionServices)
    {
        _unitOfWork = unitOfWork;
        _transactionServices = transactionServices;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<Transaction>> GetAll()
    {
        var transactions = await _transactionServices.GetTransactionAsync(User);
        return Ok(transactions);
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<PerformTransactionResponse>> PerformTransaction([FromBody] PerformTransactionRequest performTransactionRequest)
    {
        var transaction = await _transactionServices.PerformTransactionAsync(User, performTransactionRequest);
        return Ok(transaction);
    }

}