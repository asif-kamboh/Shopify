using GraphQL;

namespace Service.Shopify.Requests.GraphQl;

public interface IGraphQlRequest
{
    object? Variables { get; }

    GraphQLRequest ToGraphQlRequest();
}