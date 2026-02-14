namespace BancoSimplificado.Api.Interfaces.Repositories;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    ITransactionRepository TransactionRepository { get; }
    Task CommitAsync();
}