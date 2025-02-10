using GraphQL;
using Service.Shopify.Requests.GraphQl;

namespace Service.Shopify.Abstractions.Clients;

public interface IGraphQlClientBase
{
    Task<GraphQLResponse<T>> RunQueryAsync<T>(string query, object? variables) where T : class;

    Task<GraphQLResponse<T>> RunQueryAsync<T>(IGraphQlQuery payload) where T : class;

    Task<GraphQLResponse<T>> RunMutationAsync<T>(string mutation, object? variables) where T : class;

    Task<GraphQLResponse<T>> RunMutationAsync<T>(IGraphQlMutation payload) where T : class;
}