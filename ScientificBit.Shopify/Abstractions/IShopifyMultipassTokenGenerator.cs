namespace ScientificBit.Shopify.Abstractions;

public interface IShopifyMultipassTokenGenerator
{
    /// <summary>
    /// Generate a Shopify Multipass token for the provided customer JSON data.
    /// </summary>
    /// <param name="customerJson">(<c>Required</c>) JSON representation of the customer data.</param>
    /// <returns>A Shopify Multipass token.</returns>
    /// <exception cref="ArgumentNullException">Omitting the required <c>customerJson</c> argument will throw an <c>ArgumentNullException</c>. This includes for the case where an empty or whitespace string is provided.</exception>
    string Generate(string customerJson);
}