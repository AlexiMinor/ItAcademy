using ItAcademy.Database;
using ItAcademy.Database.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ItAcademy.DataAccess.CQS.Queries.Articles;

public class GetArticleByIdQueryHandler :  IRequestHandler<GetArticleByIdQuery, Article?>
{
    private readonly ArticleAggregatorContext _context;

    public GetArticleByIdQueryHandler(ArticleAggregatorContext context)
    {
        _context = context;
    }

    public async Task<Article?> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Articles
            .Include(article => article.Source)
            .AsNoTracking()
            .SingleOrDefaultAsync(article => 
                    article.Id.Equals(request.Id),
                    cancellationToken);
    }
}