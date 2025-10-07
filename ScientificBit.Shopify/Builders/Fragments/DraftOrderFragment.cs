using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Builders.Fragments;

public sealed class DraftOrderFragment : GraphQlFragment
{
    public DraftOrderFragment() : base("draftOrder")
    {
        var orderFragment = new GraphQlFragment("order");
        orderFragment.AddFields(new[] { "id", "name" });
        AddFields(new []{"id", "name"});
        AddFragment(orderFragment);
    }
}