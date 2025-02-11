namespace ScientificBit.Shopify.Models;

public class ShopifyPriceSet
{
    public double Value => ShopMoney?.Amount ?? 0;

    public ShopifyMoneyV2? ShopMoney { get; set; }

    public ShopifyMoneyV2? PresentmentMoney { get; set; }
}