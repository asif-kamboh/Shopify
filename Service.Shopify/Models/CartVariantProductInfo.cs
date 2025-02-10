using Service.Shopify.Enums;

namespace Service.Shopify.Models;

public class CartVariantProductInfo : ShopifyResourceModel
{
    public string Title { get; set; } = string.Empty;

    public string? ProductType { get; set; }

    // TODO move order limit and duration to metafields
    public ShopifyItemValue<int>? OrderLimit { get; set; }

    public ShopifyItemValue<int>? OrderLimitDuration { get; set; }

    public bool IsVoucher() =>
        ProductTypes.Voucher.Equals(ProductType?.Trim(), StringComparison.InvariantCultureIgnoreCase);    
}