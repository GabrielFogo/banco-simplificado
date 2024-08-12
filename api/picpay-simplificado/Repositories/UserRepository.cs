using picpay_simplificado.Context;
using picpay_simplificado.Interfaces.Repositories;
using picpay_simplificado.Models;

namespace picpay_simplificado.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }
}