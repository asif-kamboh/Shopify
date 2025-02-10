using Service.Shopify.Requests.GraphQl;

namespace Service.Shopify.Requests.Admin.Args;

public class ShippingLinesConnectionArgs : GraphQlConnectionArgs
{
    public bool IncludeRemovals { get; set; }
}