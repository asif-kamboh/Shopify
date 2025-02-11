using Service.Shopify.Requests.GraphQl;

namespace Service.Shopify.Builders.Fragments;

public sealed class MoneyV2Fragment : GraphQlFragment
{
    public MoneyV2Fragment(string name) : base(name)
    {
        AddFields(new[] {"amount", "currencyCode"});
    }
}