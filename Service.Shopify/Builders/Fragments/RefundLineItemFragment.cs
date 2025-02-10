using Service.Shopify.Requests.GraphQl;

namespace Service.Shopify.Builders.Fragments;

public sealed class RefundLineItemFragment : GraphQlFragment
{
    public RefundLineItemFragment(string name, IGraphQlQueryArgs? args = null) : base(name, args)
    {
        AddFields(new[] {"id", "quantity", "restocked"});
        AddFragment(new ShopifyIdFragment("lineItem"));
        AddFragment(new ShopifyIdFragment("location"));
        AddFragment(new MoneyBagFragment("priceSet"));
        AddFragment(new MoneyBagFragment("subtotalSet"));
    }
}