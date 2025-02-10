namespace Service.Shopify.Models;

public class ProductBundleComponentQuantityOption
{
    public string? Name { get; set; }

    public IList<ProductBundleComponentQuantityOptionValue>? Values { get; set; }

    public ProductOption? ParentOption { get; set; }
}