using System.Diagnostics;
using System.Numerics;
using System.ServiceModel.Syndication;
using System.Xml;
using HtmlAgilityPack;
using ItAcademy.DataAccess;
using ItAcademy.DataAccess.CQS.Commands.Articles;
using ItAcademy.DataAccess.CQS.Queries.Articles;
using ItAcademy.Database;
using ItAcademy.Database.Entities;
using ItAcademy.DTOs;
using ItAcademy.Services.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ItAcademy.Services;

public class ArticleService : IArticleService
{
    private readonly ArticleAggregatorContext _context;
    private readonly ILogger<ArticleService> _logger;
    //50
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMediator _mediator;
    public ArticleService(ArticleAggregatorContext context, 
        ILogger<ArticleService> logger, IUnitOfWork unitOfWork, 
        IMediator mediator)
    {
        _context = context;
        _logger = logger;
      
        _unitOfWork = unitOfWork;
        _mediator = mediator;
    }

    public async Task<ArticleDto[]> GetArticlesAsync(int pageSize, int pageNumber, CancellationToken token = default)
    {
      return await _mediator.Send(new GetArticlesByPageNumberAndPageSizeQuery()
        {
            PageSize = pageSize,
            PageNumber = pageNumber
        }, token);
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
        return await _unitOfWork.Articles.GetById(id);
        //return await _context.Articles
        //    .SingleOrDefaultAsync(article => article.Id.Equals(id));
    }

    public async Task<int> AddArticleAsync(Article article)
    {
        await _context.Articles.AddAsync(article);
        //_articleRepository.a
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
        try
        {
            var sources = await _context.Sources
                .Where(source => !string.IsNullOrEmpty(source.RssUrl))
                .ToArrayAsync();

            //var tasks = new List<Task>();
            foreach (var s in sources)
            {
                await GetRssData(s);
            }
            var articles = await GetArticlesInfoWithoutText();

            foreach (var article in articles)
            {
                await UpdateText(article);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        //get id from sources in dbContext
        
        //await Task.WhenAll(tasks);
    }

    private async Task GetRssData(Source? source, CancellationToken token = default)
    {
        if (source?.RssUrl != null)
            using (var xmlReader = XmlReader.Create(source.RssUrl))
            {
                var syndicationFeed = SyndicationFeed.Load(xmlReader);
            
                var articles = syndicationFeed.Items
                    .Select(it => new ArticleDto()
                    {
                        Id = Guid.NewGuid(),
                        Title = it.Title.Text,
                        OriginalUrl = it.Id,
                        Description = it.Summary?.Text,
                        PublicationDate = it.PublishDate.DateTime,
                        SourceId = source.Id
                    }
                ).ToArray();
                
                await _mediator.Send(
                    new InsertUniqueArticlesFromRssDataCommand()
                    {
                        Articles = articles
                    }, token);
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

    private async Task Test()
    {
        var article = new Article() { /*some data*/};
        var source = new Source() { /*some data*/ };
        var ct = new CancellationToken();

        await _unitOfWork.Articles.Add(article, ct);
        await _unitOfWork.Sources.Add(source, ct);
        await _unitOfWork.Commit(ct);
        //add to some more repositories

    }
}