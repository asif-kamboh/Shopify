using ScientificBit.Shopify.Models;
using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Requests.Admin.Args;

public class VariantsConnectionArgs : GraphQlConnectionArgs
{
    public VariantsQueryParams? Query { get; set; }

    public ShopifySortKey? SortKey { get; set; }
}

public class VariantsQueryParams : ProductsCommonQueryParams
{
    // collection
    public string? CollectionId { get; set; }

    // product_id
    public long? ProductId { get; set; }

    // product_ids
    public IList<long>? ProductIds { get; set; } 

    // product_status
    public int? ProductStatus { get; set; }

    // exclude_composite
    public bool? ExcludeComposite { get; set; }

    public bool? Taxable { get; set; }

    // inventory_quantity
    public int? InventoryQuantity { get; set; }
    // location_id
    public long? LocationId { get; set; }

    public string? Option1 { get; set; }

    public string? Option2 { get; set; }

    public string? Option3 { get; set; }

    protected override IList<string> SerializeParams()
    {
        var tokens = base.SerializeParams();

        if (!string.IsNullOrEmpty(CollectionId)) tokens.Add($"collection:{CollectionId}");

        if (!string.IsNullOrEmpty(Option1)) tokens.Add($"option1:{Option1}");
        if (!string.IsNullOrEmpty(Option2)) tokens.Add($"option2:{Option2}");
        if (!string.IsNullOrEmpty(Option3)) tokens.Add($"option3:{Option3}");

        if (LocationId.HasValue) tokens.Add($"location_id:{LocationId.Value}");
        if (InventoryQuantity.HasValue) tokens.Add($"inventory_quantity:{InventoryQuantity.Value}");

        if (Taxable.HasValue) tokens.Add($"taxable:{Taxable}");

        var productStatus = BuildProductStatusQueryValue(ProductStatus);
        if (!string.IsNullOrEmpty(productStatus))
        {
            tokens.Add($"product_status:{productStatus}");
        }

        if (ExcludeComposite.HasValue) tokens.Add($"exclude_composite:{ExcludeComposite.Value}");

        switch (ProductIds)
        {
            case {Count: > 1}:
                tokens.Add($"product_ids:{string.Join(",", ProductIds)}");
                break;
            case {Count: > 0}:
                tokens.Add($"product_id:{ProductIds[0]}");
                break;
            default:
                if (ProductId.HasValue)
                {
                    tokens.Add($"product_id:{ProductId.Value}");
                }
                break;
        }

        return tokens;
    }
}
