using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Builders.Fragments;

public sealed class MoneyBagFragment : GraphQlFragment
{
    public MoneyBagFragment(string name) : base(name)
    {
        AddFragment(new MoneyV2Fragment("shopMoney"));
        AddFragment(new MoneyV2Fragment("presentmentMoney"));
    }
}