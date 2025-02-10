using Service.Shopify.Requests.GraphQl;

namespace Service.Shopify.Requests.Admin.Args;

public class InventoryLevelArgs : GraphQlQueryArgs
{
    public string LocationId { get; set; } = string.Empty;    
}