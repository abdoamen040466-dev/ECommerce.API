using E_Commerce.Service.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.web.Handler;
public class NotFoundExceptionHandler(ILogger<NotFoundExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception ex, CancellationToken cancellationToken)
    {
        if (ex is NotFoundException notFound)
        {
            logger.LogError("Something Went Wrong {message}", notFound.Message);

            var problem = new ProblemDetails
            {
                Title = "Error Processing The HTTP Request",
                Detail = notFound.Message,
                Instance = context.Request.Path,
                Status = StatusCodes.Status404NotFound
            };
            context.Response.StatusCode = problem.Status.Value;
            await context.Response.WriteAsJsonAsync(problem, cancellationToken);
            return true;
        }
        return false;
    }
}
