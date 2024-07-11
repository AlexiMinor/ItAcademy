using ItAcademy.Database.Entities;

namespace ItAcademy.Services.Abstractions;

public interface IArticleRateService
{
    Task SetArticleRateAsync(Guid articleId, double newRate, CancellationToken token);
}