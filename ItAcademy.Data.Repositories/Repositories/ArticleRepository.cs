using ItAcademy.Database;
using ItAcademy.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace ItAcademy.DataAccess.Repositories;

public class ArticleRepository : Repository<Article>, IArticleRepository
{
    public ArticleRepository(ArticleAggregatorContext context)
        : base(context)
    {
    }

    public async Task<List<Article>> GetBySourceId(Guid sourceId, CancellationToken token = default)
    {
        return await _dbSet.Where(article => article.SourceId.Equals(sourceId)).ToListAsync(token);
    }

    //public async Task Add(Article entity, CancellationToken token = default)
    //{
    //    await _dbSet.AddAsync(entity, token);
    //}

    //public async Task AddRange(IEnumerable<Article> entities, CancellationToken token = default)
    //{
    //    await _dbSet.AddRangeAsync(entities, token);
    //}

}