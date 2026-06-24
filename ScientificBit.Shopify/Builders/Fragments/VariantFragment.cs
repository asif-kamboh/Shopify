using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Builders.Fragments;

public class VariantFragment : GraphQlFragment
{
    private static readonly string[] DefaultFields =
    {
        "id", "title", "displayName", "availableForSale", "sku", "barcode", "price", "taxable",
        "sellableOnlineQuantity", "compareAtPrice", "inventoryQuantity", "createdAt"
    };

    public VariantFragment(string name, IGraphQlQueryArgs? args = null) : base(name, args)
    {
        base.AddFields(DefaultFields);
    }
}