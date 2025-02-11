using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Requests.Admin.Args;

public class OrderTransactionArgs : GraphQlQueryArgs
{
    public int? First { get; set; }

    public bool? Capturable { get; set; }

    public bool? ManuallyResolvable { get; set; }
}