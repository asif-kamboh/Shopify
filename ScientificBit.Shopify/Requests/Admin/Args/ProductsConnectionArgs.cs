using ScientificBit.Shopify.Requests.GraphQl;
using ScientificBit.Shopify.Enums;

namespace ScientificBit.Shopify.Requests.Admin.Args;

public class ProductsConnectionArgs : GraphQlConnectionArgs
{
    public ProductsQueryParams? Query { get; set; }

    public string? SortKey { get; set; }
}

public class ProductsQueryParams : ProductsCommonQueryParams
{
    public string? Handle { get; set; }

    /// <summary>
    /// ProductStatus enum
    /// </summary>
    public int? Status { get; set; }

    public ProductInventoryTotalParam? InventoryTotal { get; set; } 

    public bool? OutOfStock { get; set; }

    public bool? Bundles { get; set; }

    public long? CollectionId { get; set; }

    public long? VariantId { get; set; }

    public string? VariantTitle { get; set; }

    public GraphQlCreatedAtQueryStringParam? CreatedAt { get; set; }

    protected override IList<string> SerializeParams()
    {
        var tokens = base.SerializeParams();

        if (!string.IsNullOrEmpty(Handle)) tokens.Add($"handle:{Handle}");
        if (!string.IsNullOrEmpty(VariantTitle)) tokens.Add($"variant_title:{VariantTitle}");

        if (VariantId.HasValue) tokens.Add($"variant_id:{VariantId.Value}");

        var productStatus = BuildProductStatusQueryValue(Status);
        if (!string.IsNullOrEmpty(productStatus))
        {
            tokens.Add($"status:{productStatus}");
        }

        if (OutOfStock.HasValue) tokens.Add($"out_of_stock_somewhere:{OutOfStock.Value}");
        if (Bundles.HasValue) tokens.Add($"bundles:{Bundles.Value}");
        if (CollectionId.HasValue) tokens.Add($"collection_id:{CollectionId.Value}");
        if (InventoryTotal != null) tokens.Add(InventoryTotal.ToString());

        return tokens;
    }
}