using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Requests.Admin.Args;

public class RefundArgs : GraphQlQueryArgs
{
    public int? First { get; set; }
}