using ItAcademy.Database.Entities;
using ItAcademy.DTOs;

namespace ItAcademy.Services.Abstractions;

public interface IArticleService
{
    Task<ArticleDto[]> GetArticlesAsync(int pageSize, int pageNumber, CancellationToken token = default);
    Task<Article?[]> GetTopAsync(int take);
    Task<ArticleDto?> GetArticleByIdAsync(Guid id);
    Task<int> AddArticleAsync(Article? article);
    Task<int> EditArticleAsync(Article updatedArticle, CancellationToken token = default);
    Task<int> GetArticlesCountAsync();
    Task AggregateAsync();
    Task SetRateAsync(Guid id, double? newRate, CancellationToken token = default);
}