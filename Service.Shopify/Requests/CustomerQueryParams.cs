using Refit;

namespace Service.Shopify.Requests;

public class CustomerQueryParams
{
    [AliasAs("fields")]
    public string Fields => "id,phone,email,state";
}