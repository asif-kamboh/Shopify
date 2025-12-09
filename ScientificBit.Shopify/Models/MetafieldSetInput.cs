using ScientificBit.Shopify.Enums;

namespace ScientificBit.Shopify.Models;

public class MetafieldSetInput : MetafieldIdentifier
{
    public string? Type { get; set; } = MetafieldTypes.SingleLineText;

    public string Value { get; set; } = string.Empty;
}