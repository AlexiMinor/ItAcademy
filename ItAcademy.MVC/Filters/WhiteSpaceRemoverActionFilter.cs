using Microsoft.AspNetCore.Mvc.Filters;

namespace ItAcademy.MVC.Filters;

public class WhiteSpaceRemoverActionFilter : Attribute, IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        //some algorithm to clean whitespaces
        //using (var ms = new MemoryStream())
        //{
        //    response.Body.CopyTo(ms);
            
        //}
        //response.Body= r
    }
}