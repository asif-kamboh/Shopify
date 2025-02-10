using Service.Shopify.Requests.GraphQl;

namespace Service.Shopify.Requests.Admin.Args;

public class OrderTransactionArgs : GraphQlQueryArgs
{
    public int? First { get; set; }

    public bool? Capturable { get; set; }

    public bool? ManuallyResolvable { get; set; }
}