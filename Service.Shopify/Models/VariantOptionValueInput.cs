namespace Service.Shopify.Models;

public class VariantOptionValueInput
{
    public string? Id { get; set; }

    public string? Name { get; set; }

    public string? OptionId { get; set; }

    public string? OptionName { get; set; }
        
    public string? LinkedMetafieldValue { get; set; }
}