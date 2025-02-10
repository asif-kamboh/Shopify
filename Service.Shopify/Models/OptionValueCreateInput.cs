namespace Service.Shopify.Models;

public class OptionValueCreateInput
{
    public string Name { get; set; } = string.Empty;

    public string LinkedMetafieldValue { get; set; } = string.Empty;
}