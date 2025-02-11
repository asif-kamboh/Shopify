using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Builders.Fragments;

public sealed class MetafieldsFragment : GraphQlNodesFragment<MetafieldFragment>
{
    public MetafieldsFragment(string name, GraphQlConnectionArgs args) : base(name, args)
    {
    }
}