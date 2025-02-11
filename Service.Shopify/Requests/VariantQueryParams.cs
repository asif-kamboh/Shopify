using Service.Shopify.Enums;

namespace Service.Shopify.Requests;

public class VariantQueryParams
{
    public string? Query { get; set; }

    public long? ProductId { get; set; }

    public long[]? ProductIds { get; set; }

    public string? Title { get; set; }

    public string? Sku { get; set; }

    public string? Barcode { get; set; }

    public string? Tag { get; set; }

    public string? NotTag { get; set; }

    public long? CollectionId { get; set; }

    public bool? IsGiftCard { get; set; }

    public bool? ExcludeComposite { get; set; }

    public long? MinId { get; set; }

    public long? MaxId { get; set; }

    public int? Quantity { get; set; }
    
    public long? LocationId { get; set; }

    public ProductStatus? Status { get; set; }

    public string? ProductType { get; set; }

    public string[]? Vendors { get; set; }

    public DateTime? MinUpdatedAt { get; set; }

    public DateTime? MaxUpdatedAt { get; set; }
}