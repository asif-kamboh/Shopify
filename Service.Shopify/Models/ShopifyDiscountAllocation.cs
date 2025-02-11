namespace Service.Shopify.Models;

public class ShopifyDiscountAllocation
{
    public double Amount => AllocatedAmountSet?.Value ?? 0;

    public ShopifyPriceSet? AllocatedAmountSet { get; set; }

    public ShopifyDiscountApplication? DiscountApplication { get; set; }

    public int DiscountApplicationIndex => DiscountApplication?.Index ?? 0;
}