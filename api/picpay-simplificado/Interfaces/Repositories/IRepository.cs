using System.Linq.Expressions;

namespace picpay_simplificado.Interfaces.Repositories;

public interface IRepository<T>
{
    Task<IEnumerable<T>> GetAllAsync();
    //T GetById(int id);
    Task<T?> GetAsync(Expression<Func<T, bool>> expression);
    T Create(T entity);
    T Update(T entity);
    T Delete(T entity);
}