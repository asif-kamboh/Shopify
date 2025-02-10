using Service.Shopify.Requests.GraphQl;

namespace Service.Shopify.Builders.Fragments;

public sealed class PricingValueFragment : GraphQlFragment
{
    public PricingValueFragment(string name) : base(name)
    {
        // Union fields
        AddField($"... on {new MoneyV2Fragment("MoneyV2")}");
        AddField($"... on {new PercentageValueFragment("PricingPercentageValue")}");
    }
}