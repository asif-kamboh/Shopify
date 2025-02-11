using Service.Shopify.Models;

namespace Service.Shopify.Views;

public class CustomersApiResponse
{
    public IList<ShopifyCustomerInfo?> Customers { get; set; } = new List<ShopifyCustomerInfo?>();
}