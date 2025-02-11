namespace ScientificBit.Shopify.Abstractions;

public interface IShopifyApiTokensAccessor
{
    string StorefrontApiToken { get; }

    string AdminApiToken { get; }
}