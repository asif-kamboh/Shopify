using GraphQL;

namespace ScientificBit.Shopify.Requests.GraphQl;

public abstract class GraphQlRequestBase
{
    public object? Variables { get; set; }

    public abstract GraphQLRequest ToGraphQlRequest();
}