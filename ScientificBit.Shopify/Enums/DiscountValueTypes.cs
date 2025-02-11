namespace ScientificBit.Shopify.Enums;

public static class DiscountValueTypes
{
    /// <summary>
    /// Possible values are:
    ///     "fixed_amount", "shipping", "percentage"
    /// </summary>

    public const string FixedAmount = "FIXED_AMOUNT";

    public const string Percentage = "PERCENTAGE";

    public const string Shipping = "SHIPPING";

    public static string GetValueType(bool isPercentage) => isPercentage ? Percentage : FixedAmount;
}