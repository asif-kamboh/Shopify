namespace Service.Shopify.Enums;

public static class ShopifyAuthHeaders
{
    public const string ChannelIdHeader = "X-Shop-Channel-Id";

    public const string WebhookAuthHeader = "x-shopify-hmac-sha256";

    public const string StorefrontAccessToken = "X-Shopify-Storefront-Access-Token";

    public const string AdminApiAccessToken = "X-Shopify-Access-Token";
}