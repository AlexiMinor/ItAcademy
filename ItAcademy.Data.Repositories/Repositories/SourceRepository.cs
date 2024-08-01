using ItAcademy.Database;
using ItAcademy.Database.Entities;

namespace ItAcademy.DataAccess.Repositories;

public class SourceRepository : Repository<Source>
{
    public SourceRepository(ArticleAggregatorContext context)
        : base(context)
    {
    }
}