namespace ScientificBit.Shopify.Models;

public class ShopifyDiscountApplication
{
    public string? AllocationMethod { get; set; }

    public int? Index { get; set; }

    public string? TargetSelection { get; set; }

    public string? TargetType { get; set; }

    public string? Title { get; set; }

    public ShopifyPricingValue? Value { get; set; }

    public string Type => IsPercentage() ? "percentage" : "fixed_amount";

    public bool IsPercentage() => Value?.Percentage != null;

    public double GetValue() => (IsPercentage() ? Value?.Percentage : Value?.Amount) ?? 0;
}