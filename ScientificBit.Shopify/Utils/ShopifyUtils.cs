using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace ScientificBit.Shopify.Utils;

public static class ShopifyUtils
{
    private const string PrefixForCheckoutGid = "gid://shopify/Checkout/";
    private const string CheckoutTokenRegexPattern = $"{PrefixForCheckoutGid}([^?]+)";

    public static string? GetCheckoutToken(string checkoutId)
    {
        Match match = Regex.Match(checkoutId, CheckoutTokenRegexPattern);
        var checkoutToken = match.Success ? match.Groups[1].Value : null;
        return checkoutToken;
    }

    public static string? GetCheckoutId(string? token)
    {
        if (string.IsNullOrEmpty(token)) return token;
        var regex = new Regex(CheckoutTokenRegexPattern);
        return regex.IsMatch(token) ? token : $"{PrefixForCheckoutGid}{token}";
    }

    public static long GetNumericId(string? resourceId)
    {
        if (string.IsNullOrWhiteSpace(resourceId)) return 0;

        var token = resourceId.Split("/").LastOrDefault();

        return long.TryParse(token, out var numericId) ? numericId : 0;
    }

    public static string GetLocationId(string? locationId)
    {
        if (string.IsNullOrEmpty(locationId)) return "";
        return long.TryParse(locationId, out var numericId) ? $"gid://shopify/Location/{numericId}" : locationId;
    }

    public static string GetProductId(long productId) => $"gid://shopify/Product/{productId}";

    public static string GetVariantId(long variantId) => $"gid://shopify/ProductVariant/{variantId}";

    public static string GetOrderId(long orderId) => $"gid://shopify/Order/{orderId}";

    /// <summary>
    /// Computes Hash using HMACSHA256 algorithm
    /// </summary>
    /// <param name="inputString"></param>
    /// <param name="secretKey"></param>
    /// <returns>string</returns>
    public static string ComputeHmacSha256(string inputString, string secretKey)
    {
        var keyBytes = Encoding.UTF8.GetBytes(secretKey);
        var inputBytes = Encoding.UTF8.GetBytes(inputString);

        using var hmac = new HMACSHA256(keyBytes);
        var hashBytes = hmac.ComputeHash(inputBytes);
        var hmacBase64 = Convert.ToBase64String(hashBytes);
        return hmacBase64;
    }
}