using Service.Shopify.Requests.Admin.Args;
using Service.Shopify.Requests.GraphQl;

namespace Service.Shopify.Builders.Fragments;

public sealed class RefundFragment : GraphQlFragment
{
    public RefundFragment(string name, RefundArgs? args = null) : base(name, args)
    {
        AddFields(new[] {"id", "createdAt", "note", "updatedAt"});
        AddFragment(new GraphQlNodesFragment<RefundLineItemFragment>("refundLineItems", new GraphQlConnectionArgs
        {
            First = 10
        }));
        AddFragment(new GraphQlNodesFragment<RefundShippingLineFragment>("refundShippingLines",
            new GraphQlConnectionArgs
            {
                First = 10
            }));
    }
}