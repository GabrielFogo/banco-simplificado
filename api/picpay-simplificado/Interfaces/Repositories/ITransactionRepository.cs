using BancoSimplificado.Api.Models;

namespace BancoSimplificado.Api.Interfaces.Repositories;

public interface ITransactionRepository : IRepository<Transaction>
{
    public Task<IEnumerable<Transaction>> GetTransactionsAsync(string email);
}