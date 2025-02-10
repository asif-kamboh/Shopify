namespace Service.Shopify.Models;

public class CartVariantInfo : ShopifyResourceModel
{
    public string Title { get; set; } = string.Empty;

    public string Barcode { get; set; } = string.Empty;

    public string Sku { get; set; } = string.Empty;

    public bool CurrentlyNotInStock { get; set; }

    public int QuantityAvailable { get; set; }

    public bool AvailableForSale { get; set; }

    public ShopifyMoneyV2? Price { get; set; }

    public bool RequiresShipping { get; set; }

    public CartVariantProductInfo? Product { get; set; }

    public bool IsVoucher() => Product?.IsVoucher() ?? false;    
}