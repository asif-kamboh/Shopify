using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Builders.Fragments;

public sealed class ShippingLinesFragment : GraphQlNodesFragment<ShippingLineFragment>
{
    public ShippingLinesFragment(string name, GraphQlConnectionArgs args) : base(name, args)
    {
    }
}