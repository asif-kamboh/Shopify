using Service.Shopify.Requests.GraphQl;

namespace Service.Shopify.Builders.Fragments;

public sealed class DiscountAllocationFragment : GraphQlFragment
{
    public DiscountAllocationFragment(string name) : base(name)
    {
        AddFragment(new MoneyBagFragment("allocatedAmountSet"));
        AddFragment(new DiscountApplicationFragment("discountApplication"));
    }
}