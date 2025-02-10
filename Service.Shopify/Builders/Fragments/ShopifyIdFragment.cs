using Service.Shopify.Requests.GraphQl;

namespace Service.Shopify.Builders.Fragments;

public sealed class ShopifyIdFragment : GraphQlFragment
{
    public ShopifyIdFragment(string name, IGraphQlQueryArgs? args = null) : base(name, args)
    {
        AddField("id");
    }
}