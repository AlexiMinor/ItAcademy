using ItAcademy.Database;
using ItAcademy.Mappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ItAcademy.DataAccess.CQS.Commands.Articles;

public class InsertUniqueArticlesFromRssDataCommandHandler :
    IRequestHandler<InsertUniqueArticlesFromRssDataCommand>
{
    private readonly ArticleAggregatorContext _dbContext;
    
    public InsertUniqueArticlesFromRssDataCommandHandler(ArticleAggregatorContext dbContext)  
    {
        _dbContext = dbContext;
    }
    
    public async Task Handle(InsertUniqueArticlesFromRssDataCommand command, 
        CancellationToken cancellationToken = default)
    {
        var existedArticleUrls = await _dbContext.Articles
            .AsNoTracking()
            .Select(article => article.OriginalUrl)
            .ToArrayAsync(cancellationToken);
        
        var articles = command.Articles
            .Where(article => !existedArticleUrls.Contains(article.OriginalUrl))
            .Select(ArticleMapper.ArticleDtoToArticle)
            .ToArray();
        
        await _dbContext.Articles.AddRangeAsync(articles, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}