namespace Service.Shopify.Models;

public class InventoryAdjustQuantitiesInput
{
    public string Name { get; set; } = "available"; // "available" or "on_hand" or "committed", "reserved"

    public string Reason { get; set; } = "other"; // See for reasons: https://shopify.dev/docs/apps/build/orders-fulfillment/inventory-management-apps/manage-quantities-states#set-inventory-quantities-on-hand

    public IList<InventoryChangeInput> Changes { get; set; } = new List<InventoryChangeInput>();
}