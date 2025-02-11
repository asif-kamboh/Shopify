using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Builders.Fragments;

public sealed class DiscountApplicationFragment : GraphQlFragment
{
    public DiscountApplicationFragment(string name) : base(name)
    {
        AddFields(new[] {"allocationMethod", "index", "targetSelection", "targetType"});
        AddFragment(new PricingValueFragment("value"));
    }
}