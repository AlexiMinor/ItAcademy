using ItAcademy.Database.Entities;

namespace ItAcademy.Services.Abstractions;

public interface IArticleService
{
    Task<Article?[]> GetArticlesAsync(int pageSize, int pageNumber);
    Task<Article?[]> GetTopAsync(int take);
    Task<Article?> GetArticleByIdAsync(Guid id);
    Task<int> AddArticleAsync(Article article);
    Task<int> EditArticleAsync(Article updatedArticle, CancellationToken token);
    Task<int> GetArticlesCountAsync();
    Task AggregateAsync();
    Task SetRateAsync(Guid id, double? newRate, CancellationToken token = default);
}