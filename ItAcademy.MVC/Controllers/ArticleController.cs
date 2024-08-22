using ItAcademy.Database.Entities;
using ItAcademy.Mappers;
using ItAcademy.MVC.Filters;
using ItAcademy.MVC.Models;
using ItAcademy.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
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
            var articlesCount = await _articleService.GetArticlesCountAsync();
            var articles = await _articleService.GetArticlesAsync(pageSize, pageNumber);
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
                Articles = articles.Select(ArticleMapper.ArticleDtoToArticleModel).ToArray(),
                Pagination = pagination
            };

            return View(model);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            //throw;
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
        if (ModelState.IsValid)
        {
            await _articleService.AddArticleAsync(ConvertArticleModelToArticle(model));
            return RedirectToAction("Index");
        }
        else
        {
            return View();
            //return BadRequest(ModelState);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Edit(Guid id)
    {
        var articles = ConvertArticleToArticleModel
            (new Article());

        return View(articles);
    }

    //[HttpPost]
    //public async Task<IActionResult> Edit(ArticleModel model)
    //{
    //    //add to database

    //    await _articleService.EditArticleAsync(ConvertArticleModelToArticle(model));
    //    return RedirectToAction("Index");
    //}

    //show top 3 articles with the highest rating for week
    [Authorize(Roles = "User")]
    public async Task<IActionResult> TopArticles()
    {
        var articles = (await _articleService.GetTopAsync(3))
            .Select(ConvertArticleToArticleModel)
            .ToArray();

        return View(articles);
    }

    [CheckId]
    public async Task<IActionResult> Details([FromRoute] Guid id, string str)
    {
        var article = new ArticleModel(); 
        //ConvertArticleToArticleModel(
        //    await _articleService.GetArticleByIdAsync(id));
        if (article != null)
        {
            //_configuration.GetReloadToken().
            article.Title = $"{article.Title} SECRET:{_configuration["AppSettings:SecretKey"]}";
        }

        //_configuration["ConnectionStrings:Default"] = "";
        return View(article);
    }

    [HttpGet]
    public IActionResult ArticleCard(ArticleModel model)
    {
        Console.WriteLine("PV");
        return PartialView(model);
    }


    [HttpGet]
    [Authorize]
    //todo temp solution, will reworked after JS 
    public async Task<IActionResult> Aggregate()
    {
       await  _articleService.AggregateAsync();
        return Ok();
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> GetArticleTitles([FromBody]SearchArticleModel model)
    {
        var titles = new List<string>()
        {
            $"{model.Title} - 1",
            $"{model.Title} - 2",
            $"{model.Title} - 3",
            $"{model.Title} - 4",
        };
        
        return Ok(titles);
    }
    //shouldn't be implemented in that way. Temp code, should be rewritten later
    //get projection
    private static ArticleModel? ConvertArticleToArticleModel(Article? article)
    {
        if (article == null)
            return null;

        var model = new ArticleModel()
        {
            ArticleId = article.Id,
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
            Id = article.ArticleId,
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