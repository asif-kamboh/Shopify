namespace ScientificBit.Shopify.Models;

public class ProductVariantUpdateInput
{
    public string Id { get; set; } = string.Empty;

    public string? Barcode { get; set; }

    public decimal? Price { get; set; }

    public decimal? CompareAtPrice { get; set; }

    public InventoryItemInput? InventoryItem { get; set; }

    public IList<InventoryLevelInput>? InventoryQuantities { get; set; }

    public string? InventoryPolicy { get; set; }

    public string? MediaId { get; set; }

    public IList<string>? MediaSrc { get; set; }

    public IList<MetafieldInput>? Metafields { get; set; }

    public IList<VariantOptionValueInput>? OptionValues { get; set; }

    public bool? RequiresComponents { get; set; }

    public bool? Taxable { get; set; }

    public string? TaxCode { get; set; }
}
