using Microsoft.AspNetCore.Mvc.Filters;

namespace ItAcademy.MVC.Filters;

public class TestResourceFilter : Attribute, IResourceFilter
{
    private readonly int _id;
    private readonly ILogger<TestResourceFilter> _logger;
    public TestResourceFilter(int id, ILogger<TestResourceFilter> logger)
    {
        _id = id;
        _logger = logger;
    }

    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        Console.WriteLine($"OnResourceExecuting {_id}");
    }

    public void OnResourceExecuted(ResourceExecutedContext context)
    {
        Console.WriteLine("OnResourceExecuted");
    }
}