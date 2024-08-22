using ItAcademy.Database.Entities;
using ItAcademy.DTOs;
using ItAcademy.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace ItAcademy.WebAPI.Controllers
{
    /// <summary>
    /// Article controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService _articleService;
        private readonly IMemoryCache _memoryCache;
        public ArticlesController(IArticleService articleService, 
            IMemoryCache memoryCache)
        {
            _articleService = articleService;
            _memoryCache = memoryCache;
        }
        //1 resource - 1 controller
        // resource - document/image/./service/collection/etc... 

        //resource & collection of resource

        /// <summary>
        /// Get article by id
        /// </summary>
        /// <param name="id">Article id</param>
        /// <returns>Article</returns>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType<ArticleDto>(200)]
        [ProducesResponseType<BadRequestResult>(400)]//add model
        [ProducesResponseType<NotFoundResult>(404)]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (!_memoryCache.TryGetValue($"article-{id}", out ArticleDto? article))
            {
                article = await _articleService.GetArticleByIdAsync(id);
                if (article == null)
                {
                    return NotFound();
                }

                _memoryCache.Set($"article-{id}", article, 
                    TimeSpan.FromDays(1));
                
                return Ok(article);
            }
            else
            {
                return Ok(article);
            }
            
        }

        [HttpGet]
        public IActionResult Get(int? pageSize, int? pageNumber)
        {
            if (pageSize.HasValue && pageNumber.HasValue)
            {
                //smth
                return Ok(new ArticleDto[] { });
            }
            else
            {
                var data = new List<ArticleDto>()
                {
                    new ArticleDto() { Id = Guid.NewGuid() },
                    new ArticleDto() { Id = Guid.NewGuid() },
                    new ArticleDto() { Id = Guid.NewGuid() }
                };

                //return data from db by id
                return Ok(data);
            }
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Post(ArticleDto articleDto)
        {
            //add to db
            return Created();
        }

        [HttpPatch("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Patch(Guid id, ArticleDto articleDto)
        {
            //add to db
            return Ok();
        } 

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(Guid id)
        {
            //add to db
            return Ok();
        }
    }
}
