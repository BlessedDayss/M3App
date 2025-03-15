namespace WebApplication1.ActionFilter;

using Microsoft.AspNetCore.Mvc.Filters;
using NLog;

public class ActionFilterLog : ActionFilterAttribute
{
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        Logger.Info($"Action {context.ActionDescriptor.DisplayName} started at {DateTime.Now}");
        await next();
        Logger.Info($"Action {context.ActionDescriptor.DisplayName} ended at {DateTime.Now}");
    }
}
