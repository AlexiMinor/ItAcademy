using System.Linq.Expressions;
using ItAcademy.Database;
using ItAcademy.Database.Entities;

namespace ItAcademy.DataAccess.Repositories;

public interface IRepository<T> where T : class, IEntity
{
    IQueryable<T> GetAsQueryable();

    Task<T?> GetById(Guid id, CancellationToken token = default);

    Task<List<T>> GetBy(Expression<Func<T, bool>> whereExpression,
        CancellationToken token = default,
        params Expression<Func<T, object>>[] includes);

    Task<int> Count(CancellationToken token = default);
    Task Add(T entity, CancellationToken token = default);
    Task AddRange(IEnumerable<T> entities, CancellationToken token = default);
}