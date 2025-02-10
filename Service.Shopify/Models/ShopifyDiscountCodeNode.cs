using Newtonsoft.Json;
using Service.Shopify.Models.Base;

namespace Service.Shopify.Models;

public class ShopifyDiscountCodeNode : ShopifyBaseModel
{
    public DiscountCodeBasic? CodeDiscount { get; set; }
}

public class DiscountCodeBasic
{
    public string Title { get; set; } = string.Empty;

    public string Summary { get; set; } = string.Empty;

    public bool AppliesOncePerCustomer { get; set; }

    public string Status { get; set; } = string.Empty;

    public int CodeCount { get; set; }

    public int AsyncUsageCount { get; set; }

    public int? UsageLimit { get; set; }

    public DateTime StartsAt { get; set; }

    public DateTime? EndsAt { get; set; }

    public string DiscountClass { get; set; } = string.Empty;

    public CustomerDiscountGets? CustomerGets { get; set; }

    public MinimumRequirementModel? MinimumRequirement { get; set; }

    public GraphQlConnection<DiscountRedeemCode>? Codes { get; set; }

    [JsonIgnore]
    public bool IsActive => "active".Equals(Status, StringComparison.InvariantCultureIgnoreCase)
                            && StartsAt <= DateTime.UtcNow
                            && (EndsAt is null || EndsAt > DateTime.UtcNow);

    [JsonIgnore]
    public int UsageCount => AsyncUsageCount;

    [JsonIgnore]
    public IList<string> DiscountCodes => Codes?.Nodes.Select(c => c.Code ?? "").ToList() ?? new List<string>();

    [JsonIgnore]
    public double? DiscountValue => CustomerGets?.Value?.Amount?.Amount;

    [JsonIgnore]
    public double? DiscountPercentage => CustomerGets?.Value?.Percentage?.Percentage;

    [JsonIgnore]
    public int? DiscountOnQuantity => CustomerGets?.Value?.Quantity?.Quantity?.Quantity;

    [JsonIgnore]
    public bool AppliesOnAllItems => CustomerGets?.Items?.AllItems ?? true;

    [JsonIgnore]
    public bool AppliesOnOneTimePurchase => CustomerGets?.AppliesOnOneTimePurchase ?? true;

    [JsonIgnore]
    public bool AppliesOnSubscription => CustomerGets?.AppliesOnSubscription ?? false;

    public class DiscountItems
    {
        public bool? AllItems { get; set; }
    }

    public class CustomerDiscountGets
    {
        public bool AppliesOnOneTimePurchase { get; set; }

        public bool AppliesOnSubscription { get; set; }

        public DiscountItems? Items { get; set; }

        public DiscountValueModel? Value { get; set; }
    }

    public class DiscountValueModel
    {
        public DiscountAmount? Amount { get; set; }

        public DiscountOnQuantityModel? Quantity { get; set; }

        public DiscountPercentageModel? Percentage { get; set; }
    }

    public class DiscountAmount
    {
        public double? Amount { get; set; }

        public bool AppliesOnEachItem { get; set; }
    }

    public class DiscountOnQuantityModel
    {
        public TargetQuantity? Quantity { get; set; }

        public DiscountEffect? Effect { get; set; }
    }

    public class TargetQuantity
    {
        public int Quantity { get; set; }
    }

    public class DiscountEffect
    {
        public DiscountAmount? Amount { get; set; }

        public DiscountPercentageModel? Percentage { get; set; }
    }

    public class DiscountPercentageModel
    {
        public double? Percentage { get; set; }
    }

    public class MinimumRequirementModel
    {
        public int? GreaterThanOrEqualToQuantity { get; set; }

        public ShopifyMoneyV2? GreaterThanOrEqualToSubtotal { get; set; }

        public double? GreaterThanOrEqualToAmount => GreaterThanOrEqualToSubtotal?.Amount;
    }

    public class DiscountRedeemCode
    {
        public string Id { get; set; } = string.Empty;

        public int AsyncUsageCount { get; set; }

        public string? Code { get; set; }
    }
}