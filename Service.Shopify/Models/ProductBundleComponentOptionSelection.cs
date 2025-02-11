namespace Service.Shopify.Models;

public class ProductBundleComponentOptionSelection
{
    public ProductOption? ComponentOption { get; set; }

    public ProductOption? ParentOption { get; set; }

    public IList<ProductBundleComponentOptionSelectionValue>? Values { get; set; }
}