using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Builders.Fragments;

public sealed class PercentageValueFragment : GraphQlFragment
{
    public PercentageValueFragment(string name) : base(name)
    {
        AddField("percentage");
    }
}