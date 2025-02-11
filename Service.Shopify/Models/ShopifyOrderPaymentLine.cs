namespace Service.Shopify.Models;

public class ShopifyOrderPaymentLine
{
    public string? UserName { get; set; }

    public string PaymentOption { get; set; } = string.Empty;

    public string? PaymentSource { get; set; }

    public string? TransactionId { get; set; }

    public double Amount { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}