using Service.Shopify.Utils;

namespace Service.Shopify.Models;

public interface IShopifyBaseModel
{
    public string? Id { get; set; }

    long? GetNumericId();
}

public class ShopifyBaseModel : IShopifyBaseModel
{
    public ShopifyBaseModel()
    {
    }

    public string? Id { get; set; }

    public long? GetNumericId() => ShopifyUtils.GetNumericId(Id);
}