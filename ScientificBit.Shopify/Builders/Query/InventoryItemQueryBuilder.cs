using ScientificBit.Shopify.Builders.Fragments;
using ScientificBit.Shopify.Requests.Admin.Args;
using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Builders.Query;

public class InventoryItemQueryBuilder : GenericQueryBuilder<InventoryItemsConnectionArgs>
{
    private static readonly string[] DefaultFields =
    {
        "id", "sku", "requiresShipping", "createdAt", "updatedAt"
    };

    public static InventoryItemQueryBuilder QueryById(string inventoryItemId, string? locationId = null)
    {
        // var location = $"gid://shopify/Location/{locationId}";
        var builder = new InventoryItemQueryBuilder("inventoryItem", $"inventoryItem(id: \"{inventoryItemId}\")", DefaultFields);
        if (!string.IsNullOrEmpty(locationId))
        {
            builder.AddInventoryLevelForLocation(locationId);
        }
        return builder;
    }

    public static InventoryItemQueryBuilder QueryAll()
    {
        var builder = new InventoryItemQueryBuilder("inventoryItems", "inventoryItems", DefaultFields, new InventoryItemsConnectionArgs());
        return builder;
    }

    private InventoryItemQueryBuilder(string methodSignature, string resource, IEnumerable<string> fields, InventoryItemsConnectionArgs? args = null) : base(methodSignature, resource, fields, args)
    {
    }

    public InventoryItemQueryBuilder AddInventoryLevelForLocation(string locationId)
    {
        var args = new InventoryLevelArgs {LocationId = locationId};
        return this.AddFragment(new InventoryLevelFragment("inventoryLevel", args));
    }

    public InventoryItemQueryBuilder AddInventoryLevels(InventoryItemsConnectionArgs args)
    {
        return this.AddFragment(new GraphQlNodesFragment<InventoryLevelFragment>("inventoryLevels", args));
    }
}