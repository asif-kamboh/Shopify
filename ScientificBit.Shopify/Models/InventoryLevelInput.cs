namespace ScientificBit.Shopify.Models;

public class InventoryLevelInput
{
    public string LocationId { get; set; } = string.Empty;

    public int AvailableQuantity { get; set; }
}