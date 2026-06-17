using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Builders.Fragments;

public sealed class DraftOrderLineItemsFragment : GraphQlNodesFragment<GraphQlFragment>
{
    public DraftOrderLineItemsFragment(string name, GraphQlConnectionArgs args) : base(name, args)
    {
        AddFields(new[] { "id", "name", "title", "variantTitle", "sku", "quantity", "requiresShipping", "taxable", "isGiftCard", "vendor" });
        AddFragment(new MoneyBagFragment("originalUnitPriceSet"));
        AddFragment(new MoneyBagFragment("discountedTotalSet"));
    }
}
