using System.Text.Json.Serialization;

namespace Service.Shopify.Models;

public class ShopifyOrderDiscountApp
{
    public string Type { get; set; } = "";

    public string Title { get; set; } = "";

    public string Description { get; set; } = "";

    public string? Code { get; set; }

    public string Value { get; set; } = "0";

    [JsonPropertyName("value_type")]
    public string ValueType { get; set; } = "0";

    [JsonPropertyName("allocation_method")]
    public string AllocationMethod { get; set; } = "0";

    [JsonPropertyName("target_selection")]
    public string TargetSelection { get; set; } = "0";

    [JsonPropertyName("target_type")]
    public string TargetType { get; set; } = "0";
}