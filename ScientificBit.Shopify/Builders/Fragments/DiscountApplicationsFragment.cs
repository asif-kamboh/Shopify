using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Builders.Fragments;

public sealed class DiscountApplicationsFragment : GraphQlNodesFragment<DiscountApplicationFragment>
{
    public DiscountApplicationsFragment(string name, GraphQlConnectionArgs? args = null)
        : base(name, args ?? new GraphQlConnectionArgs { First = 5 })
    {
    }
}