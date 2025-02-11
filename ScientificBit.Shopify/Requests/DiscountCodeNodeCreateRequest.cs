namespace ScientificBit.Shopify.Requests;

public class DiscountCodeNodeCreateRequest
{
    public string Title { get; set; } = string.Empty;

    public string Code { get; set; } = string.Empty;

    public double? Amount { get; set; }

    public double? Percentage { get; set; }

    public int UsageLimit { get; set; } = 1;

    public bool AppliesOncePerCustomer { get; set; } = true;

    public bool AppliedOnAllItems { get; set; } = true;

    public string[]? CustomerIds { get; set; }

    public string[]? ExcludeCustomerIds { get; set; }

    public double? MinimumRequiredSubtotal { get; set; }

    public int? MinimumRequiredQuantity { get; set; }

    public DateTime StartsAt { get; set; } = DateTime.UtcNow;

    public DateTime? EndsAt { get; set; }
}