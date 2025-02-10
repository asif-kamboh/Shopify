namespace Service.Shopify.Models;

internal class BasicDiscountCodeModel
{
    public string? Title { get; set; }

    public string? Code { get; set; }

    public string? StartsAt { get; set; }

    public string? EndsAt { get; set; }

    public int UsageLimit { get; set; }

    public bool AppliesOncePerCustomer { get; set; }

    public CustomerSelectionModel? CustomerSelection { get; set; }

    public CustomerGetsModel? CustomerGets { get; set; }

    public MinimumRequirementModel? MinimumRequirement { get; set; }
}

internal class MinimumRequirementModel
{
    public MinimumSubtotalRequirementModel? Subtotal { get; set; }

    public MinimumQuantityRequirementModel? Quantity { get; set; }
}

internal class MinimumQuantityRequirementModel
{
    public int GreaterThanOrEqualToQuantity { get; set; } = 1;
}

internal class MinimumSubtotalRequirementModel
{
    public double GreaterThanOrEqualToSubtotal { get; set; }
}

internal class CustomerSelectionModel
{
    public bool All { get; set; } = true;

    public CustomersModel? Customers { get; set; }
}

internal class CustomersModel
{
    public string[]? Remove { get; set; } // customer gids

    public string[]? Add { get; set; } // customer gids
}

internal class CustomerGetsModel
{
    public bool AppliesOnOneTimePurchase { get; set; } = true;

    public ValueModel? Value { get; set; }

    public ItemsModel? Items { get; set; }
}

internal class ValueModel
{
    public DiscountAmountModel? DiscountAmount { get; set; }

    public double? Percentage { get; set; }
}

internal class DiscountAmountModel
{
    public double Amount { get; set; }

    public bool AppliesOnEachItem { get; set; }
}

internal class ItemsModel
{
    public bool All { get; set; }
}