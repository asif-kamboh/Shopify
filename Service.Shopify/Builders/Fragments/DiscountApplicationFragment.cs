using Service.Shopify.Requests.GraphQl;

namespace Service.Shopify.Builders.Fragments;

public sealed class DiscountApplicationFragment : GraphQlFragment
{
    public DiscountApplicationFragment(string name) : base(name)
    {
        AddFields(new[] {"allocationMethod", "index", "targetSelection", "targetType"});
        AddFragment(new PricingValueFragment("value"));
    }
}