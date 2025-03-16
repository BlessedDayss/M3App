using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using NLog;
using System.Text.Json;

public class CacheFilter : ActionFilterAttribute
{
    private readonly int _durationSeconds;
    protected readonly IMemoryCache _cache;
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

    public CacheFilter(int durationSeconds, IMemoryCache cache)
    {
        _durationSeconds = durationSeconds;
        _cache = cache;
    }

    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        // Формируем ключ кеша на основе пути и аргументов
        var cacheKey = $"{context.HttpContext.Request.Path}_{JsonSerializer.Serialize(context.ActionArguments)}";

        if (_cache.TryGetValue(cacheKey, out IActionResult cachedResult))
        {
            Logger.Info($"Cache hit for key: {cacheKey}");
            context.Result = cachedResult;
            return;
        }
        else
        {
            Logger.Info($"Cache miss for key: {cacheKey}");
        }

        var executedContext = await next();
        
        if (executedContext.Result is ObjectResult)
        {
            _cache.Set(cacheKey, executedContext.Result, TimeSpan.FromSeconds(_durationSeconds));
            Logger.Info($"Value cached for key: {cacheKey} for {_durationSeconds} seconds");
        }
    }
}
