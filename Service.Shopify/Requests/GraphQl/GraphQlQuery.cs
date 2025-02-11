using GraphQL;

namespace Service.Shopify.Requests.GraphQl;

public class GraphQlQuery : IGraphQlQuery
{
    public string Query { get; set; } = string.Empty;

    public object? Variables { get; set; }

    public GraphQLRequest ToGraphQlRequest() => new GraphQLRequest(Query, Variables);
}