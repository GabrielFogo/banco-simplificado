using picpay_simplificado.Context;
using picpay_simplificado.Interfaces.Repositories;

namespace picpay_simplificado.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private IUserRepository? _userRepository;
    private ITransactionRepository? _transactionRepository;

    public AppDbContext Context;

    public UnitOfWork(AppDbContext context)
    {
        Context = context;
    }

    public IUserRepository UserRepository
    {
        get
        {
            return _userRepository = _userRepository ?? new UserRepository(Context);
        }
    }

    public ITransactionRepository TransactionRepository
    {
        get
        {
            return _transactionRepository = _transactionRepository ?? new TransactionRepository(Context);
        }
    }

    public async Task CommitAsync()
    {
       await Context.SaveChangesAsync();
    }
}