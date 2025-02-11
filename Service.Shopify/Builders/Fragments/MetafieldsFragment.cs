using Service.Shopify.Requests.GraphQl;

namespace Service.Shopify.Builders.Fragments;

public sealed class MetafieldsFragment : GraphQlNodesFragment<MetafieldFragment>
{
    public MetafieldsFragment(string name, GraphQlConnectionArgs args) : base(name, args)
    {
    }
}