using BancoSimplificado.Api.Context;
using BancoSimplificado.Api.Interfaces.Repositories;
using BancoSimplificado.Api.Models;

namespace BancoSimplificado.Api.Repositories;

public class TransactionRepository : Repository<Transaction>, ITransactionRepository
{
    public TransactionRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Transaction>> GetTransactionsAsync(string cpf)
    {
        var allTransaction = await GetAllAsync();
        return allTransaction.Where(transaction => transaction.SenderUserCpf == cpf);
    }
}