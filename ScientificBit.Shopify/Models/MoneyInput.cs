namespace ScientificBit.Shopify.Models;

public class MoneyInput
{
    public decimal Amount { get; set; }

    public string CurrencyCode { get; set; } = string.Empty;
}
