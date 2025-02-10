using System.Text;
using System.Text.Encodings.Web;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Service.Shopify.Configuration;
using Service.Shopify.Enums;
using Service.Shopify.Utils;

namespace Service.Shopify.Auth;


/// <summary>
/// Authentication handler definition for Shopify Webhook API calls
/// </summary>
public class ShopifyWebhookAuthHandler : AuthenticationHandler<ShopifyWebhookAuthSchemeOptions>
{
    private readonly ShopifyConfig _config;
    private readonly ILogger<ShopifyWebhookAuthHandler> _logger;

    /// <inheritdoc />
    public ShopifyWebhookAuthHandler(ILoggerFactory logger,
        IOptionsMonitor<ShopifyWebhookAuthSchemeOptions> options,
        UrlEncoder encoder,
        ISystemClock clock,
        ShopifyConfig shopifyConfig) : base(options, logger, encoder, clock)
    {
        _config = shopifyConfig;
        _logger = logger.CreateLogger<ShopifyWebhookAuthHandler>();
    }

    /// <inheritdoc />
    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!Request.Headers.TryGetValue(ShopifyAuthHeaders.WebhookAuthHeader, out var shopifyHmacHeader))
        {
            _logger.LogError("No authentication header attached for webhook event");
            return AuthenticateResult.Fail("No authentication header attached.");
        }
        if (string.IsNullOrWhiteSpace(shopifyHmacHeader))
        {
            _logger.LogError("No authentication info in header for webhook event");
            return AuthenticateResult.Fail("No authentication info attached.");
        }

        Request.EnableBuffering();

        if (!Request.Body.CanRead) return AuthenticateResult.Fail("Invalid payload.");

        var reader = new StreamReader(Request.Body,Encoding.UTF8);
        var payload = await reader.ReadToEndAsync();

        Request.Body.Seek(0, SeekOrigin.Begin);

        var salesChannelId = MatchSalesChannel(payload, shopifyHmacHeader);
        if (salesChannelId is null)
        {
            _logger.LogError("Authentication failed");
            return AuthenticateResult.Fail("Unauthorized");
        }

        // var hash = ShopifyUtils.ComputeHmacSha256(payload, _webhookConfig.Key);
        // if (!hash.Equals(shopifyHmacHeader))
        // {
        //     _logger.LogError("Authentication failed");
        //     return AuthenticateResult.Fail("Unauthorized");
        // }

        var claims = new[] { new Claim(ClaimTypes.Name, "SHOPIFY WEBHOOK") };
        var identity = new ClaimsIdentity(claims, Scheme.Name);
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, Scheme.Name);

        Request.Headers.Add(ShopifyAuthHeaders.ChannelIdHeader, salesChannelId);

        return AuthenticateResult.Success(ticket);
    }

    private string? MatchSalesChannel(string payload, string? shopifyHmacHeader)
    {
        string? channelId = null;
        foreach (var channel in _config.SalesChannels)
        {
            var hash = ShopifyUtils.ComputeHmacSha256(payload, channel.WebhookApiSecret);
            if (!hash.Equals(shopifyHmacHeader)) continue;
            channelId = channel.SalesChannelId;
        }

        return channelId;
    }
}