namespace ItAcademy.MVC.Middlewares;

public class QuerySecurityCheckMiddleware
{
    private readonly RequestDelegate _next;
    private readonly string _correctSecurityToken;

    public QuerySecurityCheckMiddleware(RequestDelegate next, string correctSecurityToken)
    {
        _next = next;
        _correctSecurityToken = correctSecurityToken;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        //const string correctSecurityToken = "123";
        var securityTokenValue = context.Request.Query["security"];
        if (securityTokenValue != _correctSecurityToken)
        {
            context.Response.StatusCode = 403;
            await context.Response.WriteAsync("No Access. Invalid security token");
        }
        else
        {
            await _next.Invoke(context);
        }
    }
}


public static class QuerySecurityExtensions
{
    public static IApplicationBuilder UseQuerySecurity(this IApplicationBuilder builder, string securityValue)
    {
        return builder.UseMiddleware<QuerySecurityCheckMiddleware>(securityValue);
    }
}