namespace Service.Shopify.Views;

public class ShopifyAdminApiPaginatedResponse<TData>
{
    public IList<TData> Data { get; set; } = new List<TData>();

    public IDictionary<string, string>? NextPageParams { get; set; }
}