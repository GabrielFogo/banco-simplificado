using picpay_simplificado.Context;
using picpay_simplificado.Interfaces.Repositories;
using picpay_simplificado.Models;

namespace picpay_simplificado.Repositories;

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