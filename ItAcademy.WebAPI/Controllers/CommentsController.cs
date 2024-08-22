using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace ItAcademy.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentsController : ControllerBase
{
    private readonly IMemoryCache _memoryCache;

    public CommentsController(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    [HttpGet]
    public IActionResult Get()
    {
        
        // Code to retrieve comments from the database or any other source
        return Ok();
    }
}