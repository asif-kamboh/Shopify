using Service.Shopify.Requests.GraphQl;

namespace Service.Shopify.Builders.Fragments;

public sealed class DiscountApplicationsFragment : GraphQlNodesFragment<DiscountApplicationFragment>
{
    public DiscountApplicationsFragment(string name, GraphQlConnectionArgs? args = null)
        : base(name, args ?? new GraphQlConnectionArgs { First = 5 })
    {
    }
}