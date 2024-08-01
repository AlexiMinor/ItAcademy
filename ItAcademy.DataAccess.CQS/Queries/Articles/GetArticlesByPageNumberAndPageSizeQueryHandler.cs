using ItAcademy.Database;
using ItAcademy.DTOs;
using ItAcademy.Mappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ItAcademy.DataAccess.CQS.Queries.Articles;

public class GetArticlesByPageNumberAndPageSizeQueryHandler : IRequestHandler<GetArticlesByPageNumberAndPageSizeQuery, 
    ArticleDto[]>
{
    private readonly ArticleAggregatorContext _context;

    public GetArticlesByPageNumberAndPageSizeQueryHandler(ArticleAggregatorContext context)
    {
        _context = context;
    }

    public async Task<ArticleDto[]> Handle(GetArticlesByPageNumberAndPageSizeQuery query, 
        CancellationToken token)
    {
        return await _context.Articles
            .OrderBy(article => article.Title) //order by title
            .Skip((query.PageNumber - 1) * query.PageSize)
            .Take(query.PageSize)// take up to pageSize 
            .Include(article => article.Source)
            .AsNoTracking()
            .Select(article => ArticleMapper.ArticleToArticleDto(article))
            .ToArrayAsync(token);
    }
}