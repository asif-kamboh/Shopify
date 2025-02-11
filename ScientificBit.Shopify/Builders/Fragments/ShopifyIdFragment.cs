using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Builders.Fragments;

public sealed class ShopifyIdFragment : GraphQlFragment
{
    public ShopifyIdFragment(string name, IGraphQlQueryArgs? args = null) : base(name, args)
    {
        AddField("id");
    }
}