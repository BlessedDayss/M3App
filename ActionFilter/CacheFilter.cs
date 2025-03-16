namespace WebApplication1.ActionFilter;

using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using NLog.Targets;

public class CacheFilter : ActionFilterAttribute
{
    private readonly int _durationSeconds;
    private readonly IMemoryCache _memoryCache;

    private CacheFilter(int durationSeconds, IMemoryCache memoryCache)
    {
        _durationSeconds = durationSeconds;
        _memoryCache = memoryCache;
    }
    
    private override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var cacheKey = $"{context.HttpContext.Request.Path}_{JsonSerializer.Serialize(context.ActionArguments)}";

        if (_memoryCache.TryGetValue(cacheKey, out IActionResult cachedResult))
        {
            context.Result = cachedResult;
            return;
        }

        var executedContext = await next();

        if (exectutedContext.Result is ObjectResult objectResult)
        {
            _memoryCache.Set(cacheKey, objectResult, TimeSpan.FromSeconds(_durationSeconds));
        }

    }
    
}
