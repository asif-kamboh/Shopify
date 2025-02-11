namespace ScientificBit.Shopify.Models;

public class LinkedMetafieldCreateInput
{
    public string Key { get; set; } = string.Empty;

    public string Namespace { get; set; } = string.Empty;

    public IList<string>? Values { get; set; }
}