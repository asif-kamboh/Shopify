using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using ScientificBit.Shopify.Abstractions;
using ScientificBit.Shopify.Abstractions.Clients;
using ScientificBit.Shopify.Abstractions.Repo;
using ScientificBit.Shopify.Auth;
using ScientificBit.Shopify.Clients;
using ScientificBit.Shopify.Clients.GraphQl;
using ScientificBit.Shopify.Configuration;
using ScientificBit.Shopify.Domain;

namespace ScientificBit.Shopify.Extensions;

public static class ShopifyServicesExtension
{
    public static IServiceCollection AddShopify(this IServiceCollection services, Action<ShopifyConfigOptions> optsBuilder)
    {
        var opts = new ShopifyConfigOptions();
        optsBuilder(opts);

        var shopifyConfig = new ShopifyConfigurationBuilder().Build(opts);
        services.AddSingleton(shopifyConfig);

        if (services.All(d => d.ServiceType != typeof(IShopifyApiTokensAccessor)))
        {
            services.AddScoped<IShopifyApiTokensAccessor, DefaultApiTokensAccessor>();
        }

        if (!string.IsNullOrEmpty(shopifyConfig.MultipassSecret))
        {
            services.AddScoped<IShopifyMultipassTokenGenerator>(_ =>
                new ShopifyMultipassTokenGenerator(shopifyConfig.MultipassSecret, shopifyConfig.StoreDomain));
        }
        services.AddScoped<IAdminApiClient, AdminApiClient>();
        services.AddScoped<IStorefrontApiClient, StorefrontApiClient>();
        services.AddScoped<IShopifyMetaObjectService, ShopifyMetaObjectService>();
        services.AddScoped<IShopifyCartService, ShopifyCartService>();
        services.AddScoped<IShopifyInventoryService, ShopifyInventoryService>();
        services.AddScoped<IShopifyDiscountCodeService, ShopifyDiscountCodeService>();
        services.AddScoped<IShopifyProductsRepository, ShopifyProductsRepository>();
        services.AddScoped<IShopifyVariantsRepository, ShopifyVariantsRepository>();
        services.AddScoped<IShopifyOrdersRepository, ShopifyOrdersRepository>();
        services.AddScoped<IShopifyMetafieldsRepository, ShopifyMetafieldsRepository>();

        services.AddHttpContextAccessor();
        return services;
    }

    public static AuthenticationBuilder AddShopifyWebhookAuthentication(this AuthenticationBuilder builder, string? authSchemeName = null)
    {
        var authScheme = !string.IsNullOrEmpty(authSchemeName) ? authSchemeName : ShopifyAuthSchemes.ShopifyWebhookAuth;
        builder.AddScheme<ShopifyWebhookAuthSchemeOptions, ShopifyWebhookAuthHandler>(authScheme, _ => { });
        return builder;
    }
}