using Service.Shopify.Requests.GraphQl;

namespace Service.Shopify.Builders.Fragments;

public sealed class ShippingLineFragment : GraphQlFragment
{
    public ShippingLineFragment(string name, IGraphQlQueryArgs? args = null) : base(name, args)
    {
        AddFields(new []
        {
            "id", "title", "carrierIdentifier", "code", "deliveryCategory",
            "shippingRateHandle", "isRemoved", "custom", "source"
        });
        AddFragment(new MoneyBagFragment("currentDiscountedPriceSet"));
        AddFragment(new MoneyBagFragment("discountedPriceSet"));
        AddFragment(new MoneyBagFragment("originalPriceSet"));
        AddFragment(new DiscountAllocationFragment("discountAllocations"));
        // TODO: Add taxLines
    }
}