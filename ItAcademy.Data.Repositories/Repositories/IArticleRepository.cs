using ItAcademy.Database.Entities;

namespace ItAcademy.DataAccess.Repositories;

public interface IArticleRepository : IRepository<Article>
{
    Task<List<Article>> GetBySourceId(Guid sourceId, CancellationToken token = default);


}