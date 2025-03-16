using Microsoft.Extensions.Caching.Memory;
using WebApplication1.ActionFilter;

public class Cache : CacheFilter
{
    public Cache(IMemoryCache cache) : base(60, cache) { }
}
