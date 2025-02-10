namespace Service.Shopify.Models;

public class MetafieldInput
{
    public string Key { get; set; } = string.Empty;

    public string Namespace { get; set; } = string.Empty;

    public string Type { get; set; } = string.Empty;

    public string Value { get; set; } = string.Empty;
}