namespace picpay_simplificado.Interfaces.Repositories;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    Task CommitAsync();
}