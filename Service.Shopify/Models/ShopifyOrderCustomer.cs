using System.Text.Json.Serialization;

namespace Service.Shopify.Models;

public class ShopifyOrderCustomer
{
    public long Id { get; set; }

    public string? Email { get; set; } = string.Empty;

    public string? Phone { get; set; }

    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; } = string.Empty;

    [JsonPropertyName("last_name")]
    public string? LastName { get; set; } = string.Empty;

    [JsonPropertyName("verified_email")]
    public bool VerifiedEmail { get; set; }

    public string? Tags { get; set; } = string.Empty;
}