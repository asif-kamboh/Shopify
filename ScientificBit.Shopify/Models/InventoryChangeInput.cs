namespace ScientificBit.Shopify.Models;

public class InventoryChangeInput
{
    public string InventoryItemId { get; set; } = string.Empty;

    public string LocationId { get; set; } = string.Empty;

    public int Delta { get; set; }
}