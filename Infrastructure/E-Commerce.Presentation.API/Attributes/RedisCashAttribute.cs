using E_Commerc.ServiceAbstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace E_Commerce.Presentation.API.Attributes;
internal class RedisCashAttribute(int durationInMin = 2)
    : ActionFilterAttribute
{
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var cashService = context.HttpContext.RequestServices.GetRequiredService<ICashService>();
        string key = GenerateCachkey(context.HttpContext.Request);
        var cashValue = await cashService.GetAsync(key);
        if (cashValue is not null)
        {
            context.Result = new ContentResult
            {
                Content = cashValue,
                ContentType = "application/json",
                StatusCode = 200
            };
            return;
        }
        var actionExecutedContext = await next.Invoke();
        var result = actionExecutedContext.Result;
        if (result is OkObjectResult okResult)
        {
            await cashService.SetAsync(key, okResult.Value!, TimeSpan.FromMinutes(durationInMin));
        }

    }

    private static string GenerateCachkey(HttpRequest request)
    {
        // Collection<Key,Value>
        // Order Query String
        var sb = new StringBuilder();
        foreach (var kvp in request.Query.OrderBy(q => q.Key))
        {
            sb.Append($"{kvp.Key}-{kvp.Value}-");
        }

        return sb.ToString().Trim('-');
    }

}
