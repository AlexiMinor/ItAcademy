using Microsoft.AspNetCore.Mvc.Filters;

namespace ItAcademy.MVC.Filters;

public class CheckId : Attribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.ActionArguments.ContainsKey("id"))
        {
            context.ActionArguments["id"] = new Guid("00221626-065a-4480-a90d-aefb739ff9ed");
        }

        await next();
    }
}