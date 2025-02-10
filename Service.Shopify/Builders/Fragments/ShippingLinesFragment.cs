using Service.Shopify.Requests.GraphQl;

namespace Service.Shopify.Builders.Fragments;

public sealed class ShippingLinesFragment : GraphQlNodesFragment<ShippingLineFragment>
{
    public ShippingLinesFragment(string name, GraphQlConnectionArgs args) : base(name, args)
    {
    }
}