using GraphQL;

namespace ScientificBit.Shopify.Requests.GraphQl;

public interface IGraphQlRequest
{
    object? Variables { get; }

    GraphQLRequest ToGraphQlRequest();
}