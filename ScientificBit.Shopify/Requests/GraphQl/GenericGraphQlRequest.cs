using GraphQL;

namespace ScientificBit.Shopify.Requests.GraphQl;

internal class GenericGraphQlRequest : GraphQlRequestBase
{
    private readonly string _query;

    public GenericGraphQlRequest(string query, object? variables)
    {
        _query = query;
        Variables = variables;
    }

    public override GraphQLRequest ToGraphQlRequest()
    {
        return new GraphQLRequest
        {
            Variables = Variables,
            Query = _query
        };
    }
}
