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
        AddProduct(_ => { });
    }

    public void AddProduct(Action<LineProductFragment> fragmentBuilder)
    {
        var fragment = new LineProductFragment("product");
        fragmentBuilder.Invoke(fragment);
        AddFragment(fragment);
    }

    public void AddVariant()
    {
        AddVariant(_ => { });
    }

    public void AddVariant(Action<LineVariantFragment> fragmentBuilder)
    {
        var fragment = new LineVariantFragment("variant");
        fragmentBuilder.Invoke(fragment);
        AddFragment(fragment);
    }

    public void AddDiscountAllocations()
    {
        AddDiscountAllocations(_ => { });
    }

    public void AddDiscountAllocations(Action<DiscountAllocationFragment> fragmentBuilder)
    {
        var fragment = new DiscountAllocationFragment("discountAllocations");
        fragmentBuilder.Invoke(fragment);
        AddFragment(fragment);
    }

    public void AddDiscountedTotal()
    {
        AddFragment(new MoneyBagFragment("discountedTotalSet"));
    }
}