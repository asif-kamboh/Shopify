using Service.Shopify.Models;
using Service.Shopify.Requests;

namespace Service.Shopify.Abstractions;

public interface IShopifyDiscountCodeService
{
    Task<ShopifyDiscountCodeNode?> GetBasicDiscountCodeById(string? discountId);

    Task<ShopifyDiscountCodeNode?> GetBasicDiscountCode(string? code);

    Task CreateDiscountCodeNode(DiscountCodeNodeCreateRequest payload);

    Task<ShopifyDiscountCodeNode?> GetDiscountCodeNodeWithRedeemCodes(string code);

    Task AddDiscountRedeemCodes(string? discountCodeId, IList<string> redeemCodes);

    Task DeleteDiscountRedeemCode(string? discountCodeId, string? redeemCode);
}