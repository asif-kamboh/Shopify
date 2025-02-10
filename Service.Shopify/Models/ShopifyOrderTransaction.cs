namespace Service.Shopify.Models;

public sealed class ShopifyOrderTransaction : ShopifyBaseModel
{
    public double? Amount => AmountSet?.Value;

    public ShopifyPriceSet? AmountSet { get; set; }

    public string? PaymentId { get; set; }

    public string? AuthorizationCode { get; set; }

    public string? Kind { get; set; }

    public string? Gateway { get; set; }

    public string? Status { get; set; }

    public bool? Test { get; set; }

    public DateTime? ProcessedAt { get; set; }

    public DateTime? CreatedAt { get; set; }
}