using Service.Shopify.Requests.GraphQl;

namespace Service.Shopify.Builders.Fragments;

public sealed class RefundShippingLineFragment : GraphQlFragment
{
    public RefundShippingLineFragment(string name, IGraphQlQueryArgs? args = null) : base(name, args)
    {
        AddFields(new[] {"id"});
        AddFragment(new ShopifyIdFragment("shippingLine"));
        AddFragment(new MoneyBagFragment("subtotalAmountSet")); 
        AddFragment(new MoneyBagFragment("taxAmountSet"));
    }
}