using ItAcademy.Database.Entities;
using ItAcademy.MVC.Models;
using ItAcademy.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace ItAcademy.MVC.Controllers;

public class ArticleController : Controller
{
    private readonly IArticleService _articleService;
    private readonly IConfiguration _configuration;
    private readonly ILogger<ArticleController> _logger;

    public ArticleController(IArticleService articleService,
        IConfiguration configuration, ILogger<ArticleController> logger)
    {
        _articleService = articleService;
        _configuration = configuration;
        _logger = logger;
    }


    //show all articles
    public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 3)
    {
        try
        {
            var articles = (await _articleService.GetArticlesAsync()) //get all from db
                .OrderBy(article => article.Title) //order by title
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)// take up to pagesize 
                .Select(ConvertArticleToArticleModel)
                .ToArray();

            //5 articles
            //5/3 = 1

            var articlesCount = await _articleService.GetArticlesCountAsync();

            var pagination = new PaginationModel()
            {
                PageSize = pageSize,
                PageNumber = pageNumber,
                TotalPages = articlesCount % pageSize == 0
                    ? articlesCount / pageSize
                    : articlesCount / pageSize + 1
            };

            var model = new ArticleWithVisitorsModel()
            {
                Articles = articles,
                Pagination = pagination
            };

            return View(model);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return StatusCode(500, new { Message = e.Message });
        }

    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Create2()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ArticleModel model)
    {
        //add to database

        await _articleService.AddArticleAsync(ConvertArticleModelToArticle(model));
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(Guid id)
    {
        var articles = ConvertArticleToArticleModel
            (await _articleService.GetArticleByIdAsync(id));

        return View(articles);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ArticleModel model)
    {
        //add to database

        await _articleService.EditArticleAsync(ConvertArticleModelToArticle(model));
        return RedirectToAction("Index");
    }

    //show top 3 articles with the highest rating for week
    public async Task<IActionResult> TopArticles()
    {
        var articles = (await _articleService.GetTopAsync(3))
            .Select(ConvertArticleToArticleModel)
            .ToArray();

        return View(articles);
    }

    public async Task<IActionResult> Details([FromRoute] Guid id, string str)
    {
        var article = ConvertArticleToArticleModel(
            await _articleService.GetArticleByIdAsync(id));
        if (article != null)
        {
            //_configuration.GetReloadToken().
            article.Title = $"{article.Title} SECRET:{_configuration["AppSettings:SecretKey"]}";
        }

        _configuration["ConnectionStrings:Default"] = "";
        return View(article);
    }

    [HttpGet]
    public IActionResult ArticleCard(ArticleModel model)
    {
        Console.WriteLine("PV");
        return PartialView(model);
    }

    //shouldn't be implemented in that way. Temp code, should be rewritten later
    //get projection
    private static ArticleModel? ConvertArticleToArticleModel(Article? article)
    {
        if (article == null)
            return null;

        var model = new ArticleModel()
        {
            Id = article.Id,
            Description = article.Description,
            Text = article.Text,
            Rate = article.Rate.GetValueOrDefault(),
            PublicationDate = article.PublicationDate,
            SourceName = $"Source name {article.SourceId}",
            Title = article.Title
        };
        return model;

    }

    private static Article? ConvertArticleModelToArticle(ArticleModel? article)
    {
        if (article == null)
            return null;

        var model = new Article()
        {
            Id = article.Id,
            Description = article.Description,
            Text = article.Text,
            Rate = article.Rate,
            PublicationDate = article.PublicationDate,
            SourceId = Guid.NewGuid(),
            Title = article.Title//in case of null will be zero
        };
        return model;

    }
}