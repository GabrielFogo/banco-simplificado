using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using picpay_simplificado.Context;
using picpay_simplificado.Interfaces.Repositories;

namespace picpay_simplificado.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly AppDbContext _context;
    public Repository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T?> GetAsync(Expression<Func<T, bool>> expression)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(expression);
    }

    public T Create(T entity)
    {
        if (entity is null)
            throw new ArgumentNullException(nameof(entity));
        
        _context.Set<T>().Add(entity);
        
        return entity;
    }

    public T Update(T entity)
    {
        if (entity is null)
            throw new ArgumentNullException(nameof(entity));
        
        _context.Set<T>().Update(entity);
        
        return entity;
    }

    public T Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        return entity;
    }
}