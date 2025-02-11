using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Builders.Fragments;

public sealed class OrderLineItemsFragment : GraphQlNodesFragment<GraphQlFragment>
{
    public OrderLineItemsFragment(string name, GraphQlConnectionArgs args) : base(name, args)
    {
        AddFields(new[] {"id", "name", "title", "sku", "variantTitle", "requiresShipping", "quantity"});
        AddFragment(new MoneyBagFragment("originalUnitPriceSet"));
    }

    public void AddProduct()
    {
        AddFragment(new LineProductFragment("product"));
    }

    public void AddVariant()
    {
        AddFragment(new LineVariantFragment("variant"));
    }

    public void AddDiscountAllocations()
    {
        AddFragment(new DiscountAllocationFragment("discountAllocations"));
    }

    public void AddDiscountedTotal()
    {
        AddFragment(new MoneyBagFragment("discountedTotalSet"));
    }
}