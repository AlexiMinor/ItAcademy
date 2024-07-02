using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ItAcademy.MVC.Filters;

public class ResultFilterAttribute : Attribute, IResultFilter
{
  public void OnResultExecuting(ResultExecutingContext context)
  {
        //context.Result.ExecuteResultAsync(new ActionContext()) 
  }

    public void OnResultExecuted(ResultExecutedContext context)
    {
     
    }
}