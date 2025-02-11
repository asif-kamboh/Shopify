using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Builders.Fragments;

public sealed class DiscountAllocationFragment : GraphQlFragment
{
    public DiscountAllocationFragment(string name) : base(name)
    {
        AddFragment(new MoneyBagFragment("allocatedAmountSet"));
        AddFragment(new DiscountApplicationFragment("discountApplication"));
    }
}