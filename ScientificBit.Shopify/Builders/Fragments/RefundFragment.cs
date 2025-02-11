using ScientificBit.Shopify.Requests.Admin.Args;
using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Builders.Fragments;

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