namespace Service.Shopify.Models;

public class ShopifyInventoryQuantityLevels : List<ShopifyQuantityLevel>
{
    public int? Available => this.FirstOrDefault(q => q.Name == "available")?.Quantity; 

    public int? OnHand => this.FirstOrDefault(q => q.Name == "on_hand")?.Quantity; 
}

public class ShopifyQuantityLevel
{
    public string? Name { get; set; }

    public int Quantity { get; set; }
}
