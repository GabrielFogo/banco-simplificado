using picpay_simplificado.Models;

namespace picpay_simplificado.Interfaces.Repositories;

public interface ITransactionRepository : IRepository<Transaction>
{
    public Task<IEnumerable<Transaction>> GetTransactionsAsync(string email);
}