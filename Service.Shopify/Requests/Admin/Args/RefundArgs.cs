using Service.Shopify.Requests.GraphQl;

namespace Service.Shopify.Requests.Admin.Args;

public class RefundArgs : GraphQlQueryArgs
{
    public int? First { get; set; }
}