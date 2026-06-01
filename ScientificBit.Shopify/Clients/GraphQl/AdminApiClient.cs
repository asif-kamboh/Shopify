using System.Collections.Concurrent;
using System.Net;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ScientificBit.Shopify.Abstractions;
using ScientificBit.Shopify.Abstractions.Clients;
using ScientificBit.Shopify.Configuration;
using ScientificBit.Shopify.Enums;
using ScientificBit.Shopify.Exceptions;

namespace ScientificBit.Shopify.Clients.GraphQl;

internal class AdminApiClient : ShopifyGraphApiClient, IAdminApiClient
{
    public AdminApiClient(ShopifyConfig config, ShopifyAdminApiMessageHandler httpMessageHandler)
        : base(config.AdminGraphQlApiUrl, httpMessageHandler)
    {
    }
}

internal class ShopifyAdminApiMessageHandler : HttpClientHandler
{
    private readonly ILogger<ShopifyAdminApiMessageHandler> _logger;
    private readonly ShopifyConfig _config;
    private readonly IShopifyApiTokensAccessor _tokensAccessor;

    private readonly ConcurrentDictionary<string, AdminTokenInfo> _adminTokens = new();

    public ShopifyAdminApiMessageHandler(ILogger<ShopifyAdminApiMessageHandler> logger, ShopifyConfig config,
        IShopifyApiTokensAccessor tokensAccessor)
    {
        _logger = logger;
        _config = config;
        _tokensAccessor = tokensAccessor;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {

        var token = await GetAuthTokenAsync();
        request.Headers.Add(ShopifyAuthHeaders.AdminApiAccessToken, token);

        // Proceed with the request
        var response = await base.SendAsync(request, cancellationToken);
        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            token = await GetAuthTokenAsync(true);
            request.Headers.Add(ShopifyAuthHeaders.AdminApiAccessToken, token);
            response = await base.SendAsync(request, cancellationToken);
        }

        return response;
    }

    private async Task<string> GetAuthTokenAsync(bool refresh = false)
    {
        var channel = _tokensAccessor.GetSalesChannel();
        // For old Shopify Apps
        if (!string.IsNullOrEmpty(channel.AdminApiToken)) return channel.AdminApiToken;

        if (!refresh && _adminTokens.TryGetValue(channel.SalesChannelId, out var tokenInfo))
        {
            if (!string.IsNullOrEmpty(tokenInfo.Token) && tokenInfo.ExpiresAt > DateTime.UtcNow)
                return tokenInfo.Token;
        }

        if (string.IsNullOrEmpty(channel.ClientId) || string.IsNullOrEmpty(channel.ClientSecret)) return "";

        using var client = new HttpClient();
        client.BaseAddress = new Uri(_config.ShopifyBaseUrl);

        var response = await client.PostAsync("/admin/oauth/access_token", new FormUrlEncodedContent(new Dictionary<string, string>
        {
            {"client_id", channel.ClientId},
            {"client_secret", channel.ClientSecret},
            {"grant_type", "client_credentials"}
        }));

        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            _logger.LogError("Failed to get admin access token. StatusCode={Status}, Error={Message}",
                response.StatusCode, content);
            throw new ShopifyApiException($"Failed to get admin access token. Error={content}", response.StatusCode);
        }

        var result = JsonConvert.DeserializeObject<ShopifyTokenApiResponse>(content, new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            }
        });

        if (!string.IsNullOrEmpty(result?.AccessToken))
        {
            _adminTokens[channel.SalesChannelId] = new AdminTokenInfo
            {
                Token = result.AccessToken,
                ExpiresAt = DateTime.UtcNow.AddSeconds(result.ExpiresIn - 10)
            };
            return result.AccessToken;
        }

        _logger.LogError("Failed to get admin access token. Error={Message}", content);
        throw new ShopifyApiException($"Failed to get admin access token. Error={content}", response.StatusCode);
    }
}

internal class AdminTokenInfo
{
    public string? Token { get; set; }

    public DateTime ExpiresAt { get; set; }
}

internal class ShopifyTokenApiResponse
{
    public string AccessToken { get; set; } = string.Empty;

    public string Scope { get; set; } = string.Empty;

    public int ExpiresIn { get; set; }
}