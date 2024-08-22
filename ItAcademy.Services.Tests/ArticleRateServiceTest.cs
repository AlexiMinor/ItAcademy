using ItAcademy.Database.Entities;
using ItAcademy.Mappers;
using ItAcademy.Services.Abstractions;
using NSubstitute;

namespace ItAcademy.Services.Tests
{
    public class ArticleRateServiceTest
    {
        private List<Article> _articles = [];
        private ArticleRateService GetArticleRateServiceWithMocks(Guid articleId, double newRate)
        {
            _articles =
            [
                new Article
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Title = "Sample Article",
                    Description = "This is a sample article",
                    Text = "Lorem ipsum dolor sit amet",
                    OriginalUrl = "https://example.com/sample-article",
                    PublicationDate = DateTime.Now,
                    Rate = 3.5,
                    SourceId = Guid.NewGuid(),
                    Source = new Source
                    {
                        Id = Guid.NewGuid(),
                        Title = "Sample Source",
                        BaseUrl = "https://example.com",
                        RssUrl = "https://example.com/rss",
                        Articles = new List<Article>()
                    }
                }
            ];
            var articleServiceMock = Substitute.For<IArticleService>();

            //add substitute logic for articleServiceMock.GetArticleByIdAsync by return value from list
            articleServiceMock.GetArticleByIdAsync(articleId)
                .ReturnsForAnyArgs(
                    Task.FromResult(
                        ArticleMapper.ArticleToArticleDto(_articles.FirstOrDefault(article => article.Id.Equals(articleId)))));

            //add substitute logic for articleServiceMock.SetRateAsync by update value from listArticle
            articleServiceMock
                .SetRateAsync(articleId, newRate)
                .ReturnsForAnyArgs(Task.FromResult(1))
                .AndDoes(info =>
                {
                    _articles[0].Rate = newRate;
                });

            var ars = new ArticleRateService(articleServiceMock);

            return ars;
        }
        
        [Theory]
        [InlineData(-2)]
        [InlineData(3)]
        [InlineData(4.8)]
        [InlineData(-5)]
        [InlineData(5)]
        [InlineData(0)]
        public async Task SetArticleRateAsync_UpdateWithCorrectRate_UpdateCorrectly(double newRate)
        {

            var articleId = Guid.Parse("11111111-1111-1111-1111-111111111111");

            //ARRANGE
            var articleRateService = GetArticleRateServiceWithMocks(articleId, newRate);

            //act
            await articleRateService.SetArticleRateAsync(articleId, newRate);

            //assert
            Assert.Equal(newRate, _articles[0].Rate);
        }


        [Theory]
        [InlineData(double.NegativeInfinity)]
        [InlineData(-7)]
        [InlineData(5.1)]
        [InlineData(50)]
        [InlineData(double.PositiveInfinity)]
        public async Task SetArticleRateAsync_UpdateWithIncorrectRate_ThrowException(double newRate)
        {
            //aaa implementation
            //ARRANGE
            var articleId = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var articleRateService = GetArticleRateServiceWithMocks(articleId, newRate);
            const string exMessage = "Incorrect rate (Parameter 'newRate')";

            //act && assert
            var ex = await Assert.ThrowsAsync(typeof(ArgumentException), 
                () => articleRateService.SetArticleRateAsync(articleId, newRate));
            Assert.Equal(exMessage, ex.Message);
        }

        [Theory]
        [InlineData("432C080C-2500-480E-9E0B-27D5416CD4D9")]
        [InlineData("37435125-C20A-4A3E-8CC2-FEEF17A9C95F")]
        [InlineData("2793A5C4-F2B6-44AA-9551-0D60C118C198")]
        public async Task SetArticleRateAsync_UpdateWithIncorrectId_ThrowException(string guidValue)
        {
            //aaa implementation
            //ARRANGE
            const string exMessage = "Article with that Id doesn't exist (Parameter 'articleId')";

            var articleId = Guid.Parse(guidValue);
            var newRate = 4.5;
            var articleRateService = GetArticleRateServiceWithMocks(articleId, newRate);

            //act && assert
            var ex = await Assert.ThrowsAsync(typeof(ArgumentException),
                () => articleRateService.SetArticleRateAsync(articleId, newRate));
            Assert.Equal(exMessage, ex.Message);
        }
    }
}