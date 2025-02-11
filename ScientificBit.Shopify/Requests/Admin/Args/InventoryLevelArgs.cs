using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Requests.Admin.Args;

public class InventoryLevelArgs : GraphQlQueryArgs
{
    public string LocationId { get; set; } = string.Empty;    
}