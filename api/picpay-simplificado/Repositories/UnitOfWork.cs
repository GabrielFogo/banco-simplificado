using picpay_simplificado.Context;
using picpay_simplificado.Interfaces.Repositories;

namespace picpay_simplificado.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private IUserRepository? _userRepository;

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
    
    public async Task CommitAsync()
    {
       await Context.SaveChangesAsync();
    }
}