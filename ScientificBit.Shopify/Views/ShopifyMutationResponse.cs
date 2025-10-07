using ScientificBit.Shopify.Models;

namespace ScientificBit.Shopify.Views;

public class ShopifyMutationResponse : ShopifyMutationResponse<ShopifyBaseModel>
{
}

public class ShopifyMutationResponse<TData>
{
    public ShopifyMutationResult<TData>? Result { get; set; }
}

public class ShopifyMutationResult<TData> : AdminApiResponse
{
    public TData? Data { get; set; }
}