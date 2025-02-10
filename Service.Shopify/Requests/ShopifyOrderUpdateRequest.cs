using Refit;
using Service.Shopify.Models;

namespace Service.Shopify.Requests;

/// <summary>
/// This operation allows for updating properties of an order including
/// `buyer_accepts_marketing`, `email`, `phone`, `note`, `tags`, `metafields` and `shipping_address_attributes`.
/// It is not for editing the items of an order.
/// </summary>
public class ShopifyOrderUpdateRequest
{
    [AliasAs("order")]
    public ShopifyOrderUpdateModel? Order { get; set; }
}