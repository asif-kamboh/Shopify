using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Requests.Admin.Args;

public class InventoryItemsConnectionArgs : GraphQlConnectionArgs
{
    public InventoryLevelsQueryParams? Query { get; set; }
}

public class InventoryLevelsQueryParams
{
    public GraphQlIdQueryStringParam? Id { get; set; }

    public override string ToString()
    {
        return Id != null ? Id.ToString() : string.Empty;
    }
}