using System.Diagnostics;
using System.ServiceModel.Syndication;
using System.Xml;
using HtmlAgilityPack;
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
    public async Task<Article?[]> GetArticlesAsync(int pageSize, int pageNumber)
    {
        return await _context.Articles
                .OrderBy(article => article.Title) //order by title
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)// take up to pagesize 
                .Include(article => article.Source)
                .ToArrayAsync();
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

    public async Task<int> EditArticleAsync(Article updatedArticle, CancellationToken token)
    {
        //not real implementation
        var article = await GetArticleByIdAsync(updatedArticle.Id);
        article.Text = updatedArticle.Text;
        article.PublicationDate = DateTime.Now;
        return await _context.SaveChangesAsync(token);
    }

    public async Task<int> GetArticlesCountAsync()
    {
        return await _context.Articles.CountAsync();
    }

    public async Task SetRateAsync(Guid id, double? newRate, CancellationToken token)
    {
        var article = await _context.Articles.FirstOrDefaultAsync(a => a.Id == id, cancellationToken: token);
        if (article != null)
        {
            article.Rate = newRate;
            await _context.SaveChangesAsync(token);
        }
    }

    public async Task AggregateAsync()
    {
        var sw = new Stopwatch();
        sw.Start();
        try
        {
            var sources = await _context.Sources
                .Where(source => !string.IsNullOrEmpty(source.RssUrl))
                .ToArrayAsync();

            //var tasks = new List<Task>();
            var sw1 = new Stopwatch();
            sw1.Start();
            foreach (var s in sources)
            {
                await GetRssData(s);
            }
            sw1.Stop();
            
            var articles = await GetArticlesInfoWithoutText();

            var sw2 = new Stopwatch();
            sw2.Start();
            foreach (var article in articles)
            {
                await UpdateText(article);
            }
            sw2.Stop();
            sw.Stop();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        //get id from sources in dbContext
        
        //await Task.WhenAll(tasks);
    }

    private async Task GetRssData(Source? source)
    {
        if (source?.RssUrl != null)
            using (var xmlReader = XmlReader.Create(source.RssUrl))
            {
                var syndicationFeed = SyndicationFeed.Load(xmlReader);
                var existedArticleUrls = await _context.Articles
                    .Select(article => article.OriginalUrl)
                    .ToArrayAsync();
                var articles = syndicationFeed.Items
                    .Select(it => new Article()
                    {
                        Id = Guid.NewGuid(),
                        Title = it.Title.Text,
                        OriginalUrl = it.Id,
                        Description = it.Summary?.Text,
                        PublicationDate = it.PublishDate.DateTime,
                        SourceId = source.Id
                    }
                ).ToArray();

                var newUniqueArticles = articles
                    .Where(article => !existedArticleUrls.Contains(article.OriginalUrl))
                    .ToArray();
                
                await _context.Articles.AddRangeAsync(newUniqueArticles);
                await _context.SaveChangesAsync();
            }
    }

    private async Task<Article[]> GetArticlesInfoWithoutText()
    {
        return await _context.Articles.Where(article=>string.IsNullOrEmpty(article.Text)).ToArrayAsync();
    }

    private async Task UpdateText(Article article)
    {
        var web = new HtmlWeb();
        var doc = web.Load(article.OriginalUrl);

        var articleNode = doc.DocumentNode.SelectSingleNode("//div[@class='news-text']");
        if (articleNode != null)
        {
            var existingArticle = await _context.Articles.FirstOrDefaultAsync(a => a.Id == article.Id);
            if (existingArticle != null)
            {
                //can be inner html
                existingArticle.Text = articleNode.InnerText.Trim();
                await _context.SaveChangesAsync();
            }
        }
    }
}