using ScientificBit.Shopify.Enums;

namespace ScientificBit.Shopify.Models;

public class DiscountCodeInfo
{
    public double Amount { get; set; }

    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// Possible values are:
    ///     "fixed_amount", "shipping", "percentage"
    /// </summary>
    public string Type { get; set; } = DiscountValueTypes.FixedAmount.ToLower();
}