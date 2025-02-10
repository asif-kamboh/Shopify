using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Service.Shopify.Abstractions;
using Service.Shopify.Abstractions.Clients;
using Service.Shopify.Abstractions.Repo;
using Service.Shopify.Auth;
using Service.Shopify.Clients;
using Service.Shopify.Clients.GraphQl;
using Service.Shopify.Clients.Handlers;
using Service.Shopify.Configuration;
using Service.Shopify.Domain;

namespace Service.Shopify.Extensions;

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

        services.AddScoped<AdminRestApiMessageHandler>();
        services.AddScoped<AdminGraphQlApiMessageHandler>();
        services.AddScoped<StorefrontApiMessageHandler>();
        services.AddScoped<IAdminApiClient, AdminApiClient>();
        services.AddScoped<IStorefrontApiClient, StorefrontApiClient>();
        services.AddScoped<IShopifyMetaObjectService, ShopifyMetaObjectService>();
        services.AddScoped<IShopifyCartService, ShopifyCartService>();
        services.AddScoped<IShopifyInventoryService, ShopifyInventoryService>();
        services.AddScoped<IShopifyDiscountCodeService, ShopifyDiscountCodeService>();
        services.AddScoped<IShopifyProductsRepository, ShopifyProductsRepository>();
        services.AddScoped<IShopifyVariantsRepository, ShopifyVariantsRepository>();
        services.AddScoped<IShopifyOrdersRepository, ShopifyOrdersRepository>();

        return services;
    }

    public static AuthenticationBuilder AddShopifyWebhookAuthentication(this AuthenticationBuilder builder, string? authSchemeName = null)
    {
        var authScheme = !string.IsNullOrEmpty(authSchemeName) ? authSchemeName : ShopifyAuthSchemes.ShopifyWebhookAuth;
        builder.AddScheme<ShopifyWebhookAuthSchemeOptions, ShopifyWebhookAuthHandler>(authScheme, _ => { });
        return builder;
    }
}