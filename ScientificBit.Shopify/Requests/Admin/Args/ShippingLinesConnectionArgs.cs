using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Requests.Admin.Args;

public class ShippingLinesConnectionArgs : GraphQlConnectionArgs
{
    public bool IncludeRemovals { get; set; }
}