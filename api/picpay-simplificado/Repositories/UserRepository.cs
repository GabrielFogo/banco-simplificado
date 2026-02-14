using BancoSimplificado.Api.Context;
using BancoSimplificado.Api.Interfaces.Repositories;
using BancoSimplificado.Api.Models;

namespace BancoSimplificado.Api.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }
}