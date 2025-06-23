using ScientificBit.Shopify.Requests.Admin.Args;
using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Builders.Fragments;

public sealed class RefundFragment : GraphQlFragment
{
    public RefundFragment(string name, RefundArgs? args = null) : base(name, args)
    {
        AddFields(new[] {"id", "createdAt", "note", "updatedAt"});
        AddRefundLineItems(new GraphQlConnectionArgs {First = 10}, _ => { });
        AddRefundShippingLines(new GraphQlConnectionArgs {First = 10}, _ => { });
    }

    public void AddRefundLineItems(GraphQlConnectionArgs args, Action<GraphQlNodesFragment<RefundLineItemFragment>> fragmentBuilder)
    {
        var fragment = new GraphQlNodesFragment<RefundLineItemFragment>("refundLineItems", args);
        fragmentBuilder.Invoke(fragment);
        AddFragment(fragment);
    }

    public void AddRefundShippingLines(GraphQlConnectionArgs args, Action<GraphQlNodesFragment<RefundShippingLineFragment>> fragmentBuilder)
    {
        var fragment = new GraphQlNodesFragment<RefundShippingLineFragment>("refundShippingLines", args);
        fragmentBuilder.Invoke(fragment);
        AddFragment(fragment);
    }
}