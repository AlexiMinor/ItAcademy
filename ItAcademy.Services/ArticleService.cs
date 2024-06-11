using ItAcademy.Database;
using ItAcademy.Database.Entities;
using ItAcademy.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ItAcademy.Services;

public class ArticleService : IArticleService
{
    private readonly ArticleAggregatorContext _context;
    private readonly ILogger<ArticleService> _logger;

    public ArticleService(ArticleAggregatorContext context, ILogger<ArticleService> logger)
    {
        _context = context;
        _logger = logger;
    }
    public async Task<Article?[]> GetArticlesAsync()
    {
        //try
        //{
            return await _context.Articles.Where(article => article!.Rate >= 1).ToArrayAsync();
        //}
        //catch (Exception e)
        //{
        //    //log.error 
        //    //try to connect to reserve db
        //    // if no - exception
        //}

    }

    public async Task<Article?[]> GetTopAsync(int take)
    {
        return await _context.Articles
            .OrderByDescending(article => article!.Rate)
            .Take(take)
            .ToArrayAsync();
    }

    public async Task<Article?> GetArticleByIdAsync(Guid id)
    {
        return await _context.Articles
            .SingleOrDefaultAsync(article => article.Id.Equals(id));
    }

    public async Task<int> AddArticleAsync(Article article)
    {
        await _context.Articles.AddAsync(article);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> EditArticleAsync(Article updatedArticle)
    {
        //not real implementation
        var article = await GetArticleByIdAsync(updatedArticle.Id);
        article.Text = updatedArticle.Text;
        article.PublicationDate = DateTime.Now;
        return await _context.SaveChangesAsync();
    }

    public async Task<int> GetArticlesCountAsync()
    {
        return await _context.Articles.CountAsync();
    }
}