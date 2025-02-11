namespace Service.Shopify.Requests.GraphQl;

internal class GenericGraphQlQuery : GenericGraphQlRequest, IGraphQlQuery
{
    public GenericGraphQlQuery(string query, object? variables) : base(query, variables)
    {
    }
}