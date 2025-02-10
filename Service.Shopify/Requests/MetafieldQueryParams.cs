using Refit;

namespace Service.Shopify.Requests;

public class MetafieldQueryParams : AdminApiQueryParams
{
    [AliasAs("namespace")]
    public string? Namespace { get; set; }

    [AliasAs("key")]
    public string? Key { get; set; }
}