using System.Linq.Expressions;
using ItAcademy.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ItAcademy.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly ArticleAggregatorContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(ArticleAggregatorContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public IQueryable<T> GetAsQueryable()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<T?> GetById(Guid id, CancellationToken token = default)
        {
            return await _dbSet.SingleOrDefaultAsync(entity => entity.Id.Equals(id),
                cancellationToken: token);
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<List<T>> GetBy(Expression<Func<T, bool>> whereExpression,
            CancellationToken token = default,
            params Expression<Func<T, object>>[] includes)
        {
            var query = _context.Set<T>().Where(whereExpression);
            if (includes.Any())
            {
                query = includes.Aggregate(query,
                    (current, include) => current.Include(include));
            }
            return await query.ToListAsync(token);
        }

        public async Task<int> Count(CancellationToken token = default)
        {
            return await _dbSet.CountAsync(token);
        }

        public async Task Add(T entity, CancellationToken token = default)
        {
            await _dbSet.AddAsync(entity, token);
            //await _context.SaveChangesAsync(token);
        }

        public async Task AddRange(IEnumerable<T> entities, CancellationToken token = default)
        {
            await _dbSet.AddRangeAsync(entities, token);
            //await _context.SaveChangesAsync(token);
        }


        //public int Update(IEnumerable<T> entities)
        //{
        //    throw new NotImplementedException();
        //}

        //public int Delete(IEnumerable<T> entities)
        //{
        //    throw new NotImplementedException();
        //}

    }
}
