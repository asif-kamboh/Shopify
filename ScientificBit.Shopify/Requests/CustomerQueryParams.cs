using Refit;

namespace ScientificBit.Shopify.Requests;

public class CustomerQueryParams
{
    [AliasAs("fields")]
    public string Fields => "id,phone,email,state";
}