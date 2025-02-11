using Refit;

namespace Service.Shopify.Requests;

public abstract class AdminApiQueryParams
{
    /// <summary>
    /// Page Size
    /// </summary>
    [AliasAs("limit")]
    public int Limit { get; set; } = 50; // Default by Shopify

    /// <summary>
    /// Projection: Comma-separated fields
    /// </summary>
    [AliasAs("fields")]
    public string? Fields { get; set; }
}