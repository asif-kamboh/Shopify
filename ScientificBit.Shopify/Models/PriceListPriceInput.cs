namespace ScientificBit.Shopify.Models;

public class PriceListPriceInput
{
    public string VariantId { get; set; } = string.Empty;

    public MoneyInput Price { get; set; } = new();
}
