namespace ScientificBit.Shopify.Models;

/// <summary>
/// Defines a sort key for Shopify GET queries
/// </summary>
public class ShopifySortKey
{
    private readonly string _value;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="value"></param>
    internal ShopifySortKey(string value)
    {
        _value = value;
    }

    public override string ToString() => _value;
}