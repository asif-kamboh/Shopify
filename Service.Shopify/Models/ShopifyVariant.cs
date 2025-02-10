using Service.Shopify.Models.Base;

namespace Service.Shopify.Models;

public class ShopifyVariant : ShopifyVariantSummary
{
    public decimal? CompareAtPrice { get; set; }

    // TODO: Add contextualPricing

    public string? DefaultCursor { get; set; }
    
    public ShopifyImage? Image { get; set; }

    public ShopifyInventoryItem? InventoryItem { get; set; }

    public GraphQlConnection<ShopifyMedia>? Media { get; set; }

    public int? Position { get; set; }

    public IList<SelectedProductOption>? SelectedOptions { get; set; }

    public string? TaxCode { get; set; }

    public IList<ShopifyTranslation>? Translations { get; set; }

    public ShopifyProduct<ShopifyBaseModel>? Product { get; set; }
}