using ScientificBit.Shopify.Enums;

namespace ScientificBit.Shopify.Requests;

public class DraftOrderAppliedDiscountInput
{
    public string Amount { get; set; } = "0";

    public string? Title { get; set; }

    public string? Description { get; set; }

    public double Value { get; set; }

    public string ValueType { get; set; } = DiscountValueTypes.FixedAmount; // FIXED_AMOUNT, PERCENTAGE
}