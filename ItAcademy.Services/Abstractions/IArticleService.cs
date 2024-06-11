using ItAcademy.Database.Entities;

namespace ItAcademy.Services.Abstractions;

public interface IArticleService
{
    Task<Article?[]> GetArticlesAsync();
    Task<Article?[]> GetTopAsync(int take);
    Task<Article?> GetArticleByIdAsync(Guid id);
    Task<int> AddArticleAsync(Article article);
    Task<int> EditArticleAsync(Article updatedArticle);
    Task<int> GetArticlesCountAsync();
}