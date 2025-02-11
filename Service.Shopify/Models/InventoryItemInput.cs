namespace Service.Shopify.Models;

public class InventoryItemInput
{
    public string Sku { get; set; } = string.Empty;

    public bool RequiresShipping { get; set; }

    public bool Tracked { get; set; }

    public decimal? Cost { get; set; }

    public string? CountryCodeOfOrigin { get; set; }

    public InventoryItemMeasurementInput? Measurement { get; set; }
}