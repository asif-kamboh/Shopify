using Service.Shopify.Models.Base;

namespace Service.Shopify.Models;

public class ShopifyProductBundleComponent
{
    public ShopifyProductSummary? ComponentProduct { get; set; }

    public GraphQlConnection<ShopifyVariantSummary>? ComponentVariants { get; set; }

    public int? ComponentVariantsCount { get; set; }

    public IList<ProductBundleComponentOptionSelection>? OptionSelections { get; set; }

    public int? Quantity { get; set; }

    public ProductBundleComponentQuantityOption? QuantityOption { get; set; }
}