namespace WebApplication1.ActionFilter;

using Microsoft.AspNetCore.Mvc.Filters;
using NLog;

public class ActionFilterLog : ActionFilterAttribute
{
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        _logger.Info($"Action {context.ActionDescriptor.DisplayName} started at {DateTime.Now}");
        
        if (context.Result != null)
        {
            _logger.Info($"Action {context.ActionDescriptor.DisplayName} short-circuited at {DateTime.Now}");
            return;
        }
        await next();
        _logger.Info($"Action {context.ActionDescriptor.DisplayName} ended at {DateTime.Now}");
    }
}
