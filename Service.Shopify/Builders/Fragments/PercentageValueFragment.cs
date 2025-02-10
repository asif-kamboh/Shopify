using Service.Shopify.Requests.GraphQl;

namespace Service.Shopify.Builders.Fragments;

public sealed class PercentageValueFragment : GraphQlFragment
{
    public PercentageValueFragment(string name) : base(name)
    {
        AddField("percentage");
    }
}