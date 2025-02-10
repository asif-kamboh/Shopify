using Microsoft.AspNetCore.Http;
using Service.Shopify.Enums;

namespace Service.Shopify.Extensions;

public static class HttpContextAccessorExtensions
{
    private const string ChannelIdHeaderKey = ShopifyAuthHeaders.ChannelIdHeader;

    public static string GetShopifyChannelId(this IHttpContextAccessor contextAccessor)
    {
        var httpContext = contextAccessor.HttpContext;
        if (httpContext is null) return "";
        return httpContext.Request.Headers.TryGetValue(ChannelIdHeaderKey, out var channelId)
            ? channelId.ToString()
            : "";
    }

    public static void UpdateShopifyChannelId(this IHttpContextAccessor contextAccessor, string? channelId)
    {
        var httpContext = contextAccessor.HttpContext;
        httpContext?.Request.Headers.Add(ChannelIdHeaderKey, channelId);
    }
}