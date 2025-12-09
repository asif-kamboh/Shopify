using ScientificBit.Shopify.Models;
using ScientificBit.Shopify.Views;

namespace ScientificBit.Shopify.Abstractions.Repo;

public interface IShopifyMetafieldsRepository
{
    /// <summary>
    /// Set metafields for the given resource. Metafield values will be set regardless
    /// if they were previously created or not.
    /// **Note**: Up to 25 metafields can be set at once.
    /// </summary>
    /// <param name="metafields"></param>
    /// <returns></returns>
    Task<GraphQlResult<List<MetafieldModel>>> SetAsync(IList<MetafieldSetInput> metafields);

    /// <summary>
    /// Deletes a metafield.
    /// </summary>
    /// <param name="ownerId"></param>
    /// <param name="ns">Namespace</param>
    /// <param name="key"></param>
    /// <returns></returns>
    Task<GraphQlResult<MetafieldIdentifier?>> DeleteAsync(string ownerId, string ns, string key);

    /// <summary>
    /// Delete metafields in bulk.
    /// </summary>
    /// <param name="metafields"></param>
    /// <returns>Returns only deleted identifiers</returns>
    Task<GraphQlResult<List<MetafieldIdentifier>>> DeleteAsync(IList<MetafieldIdentifier> metafields);
}