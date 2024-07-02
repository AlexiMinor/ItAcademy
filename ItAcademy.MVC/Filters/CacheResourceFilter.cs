using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ItAcademy.MVC.Filters;

public class CacheResourceFilter : Attribute, IResourceFilter
{
    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        if (context.HttpContext.Request.Query.ContainsKey("cache"))
        {
            context.Result = new OkObjectResult(new { Data = "123"});
        }
    }

    public void OnResourceExecuted(ResourceExecutedContext context)
    {
    }


}