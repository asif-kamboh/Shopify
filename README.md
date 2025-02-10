# Introduction
Do you struggle while consuming Shopify GraphQL APIs? ScientificBit.Shopify package simplifies connectivity with Shopify Storfront and Admin APIs.

## How to Integrate
The package is built for .NET Core 8, and supports latest Shopify API version (2025-01).
<br/><br/>
He is how you can configure this package for Shopify APIs access:

### Configure Shopify APIs
```
builder.Services.AddShopify(opts =>
{
    opts.Configuration = builder.Configuration.GetSection("Shopify");
    opts.MultipassSecret = ""; // TODO: Read from ENV
    opts.StoreDomain = "https://www.scientificbit.com"; // Your store website
    opts.AddSalesChannelTokens("sb", "shopify-admin-token", "shopify-storefront-token", "shopify-api-secret");
});
```
### Add Shopify Webhook Authentication
```
builder.Services.AddAuthentication()
    .AddShopifyWebhookAuthentication(ShopifyAuthSchemes.ShopifyWebhookAuth);
```
OR with your own scheme name
```
builder.Services.AddAuthentication()
    .AddShopifyWebhookAuthentication("MyWebhookAuth");
```

### Sample Shopify AppSettings.json
```
{
  "Shopify": {
    "ApiVersion": "2025-01",
    "ShopifyBaseUrl": "https://sb2.myshopify.com",
    "StoreDomain": "www.scientificbit.com",
    "SalesChannels": [
      {
        "SalesChannelId": "sb",
        "AdminApiToken": "",
        "StorefrontApiToken": "",
        "WebhookApiSecret": "",
        "DefaultMetafieldsNamespace": "sb-ecom-app",
        "DefaultInventoryLocationId": "1231231232"
      }
    ]
  },
}
```

## Documentation
Please refer code and inline docs

## Contribution
Contribution guidelines will be added shortly

## Support The Developer
Please support me to help cover ongoing development, infrastructure costs, and the potential expansion of the project (including new features, testing, and documentation).
<br/>
Donate now via https://opencollective.com/sbshopify
