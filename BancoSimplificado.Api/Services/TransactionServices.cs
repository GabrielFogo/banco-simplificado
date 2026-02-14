using BancoSimplificado.Api.DTOs.Responses;
using BancoSimplificado.Api.DTOs.Resquests;
using BancoSimplificado.Api.Interfaces.Repositories;
using BancoSimplificado.Api.Interfaces.Services;
using BancoSimplificado.Api.Models;
using System.Security.Claims;

namespace BancoSimplificado.Api.Services;

public class TransactionServices : ITransactionServices
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserService _userService;

    public TransactionServices(IUnitOfWork unitOfWork, IUserService userService)
    {
        _unitOfWork = unitOfWork;
        _userService = userService;
    }


    public async Task<IEnumerable<Transaction>> GetTransactionAsync(ClaimsPrincipal claimsPrincipal)
    {
        var user = await _userService.GetUserFromClaims(claimsPrincipal);
        var transactions = await _unitOfWork.TransactionRepository.GetTransactionsAsync(user.Cpf);

        return transactions;
    }

    public async Task<PerformTransactionResponse> PerformTransactionAsync(ClaimsPrincipal claimsPrincipal, PerformTransactionRequest performTransactionRequest)
    {
        var senderUser = await _userService.GetUserFromClaims(claimsPrincipal);
        var recipientUser = await _unitOfWork.UserRepository.GetAsync(u => u.Cpf == performTransactionRequest.RecipientUserCpf);

        if (recipientUser is null)
            throw new Exception("O usuario destinatario nao existe");

        if (!_userService.CanUserPerformTransaction(senderUser, performTransactionRequest.Amount))
            throw new Exception("O usuario nao pode fazer uma transação");

        var transaction = new Transaction()
        {
            SenderUserCpf = senderUser.Cpf,
            RecipientUserCpf = recipientUser.Cpf,
            Amount = performTransactionRequest.Amount
        };

        senderUser.Balance -= performTransactionRequest.Amount;
        recipientUser.Balance += performTransactionRequest.Amount;

        _unitOfWork.TransactionRepository.Create(transaction);

        await _unitOfWork.CommitAsync();

        var transactionResponse = new PerformTransactionResponse()
        {
            Status = "Success",
            Message = "Transação realizada com sucesso",
            RecipientUserCpf = transaction.RecipientUserCpf,
            SenderUserCpf = transaction.SenderUserCpf,
            Amount = transaction.Amount
        };

        return transactionResponse;
    }
}