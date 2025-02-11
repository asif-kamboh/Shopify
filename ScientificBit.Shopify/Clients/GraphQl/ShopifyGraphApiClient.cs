using GraphQL;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using ScientificBit.Shopify.Exceptions;
using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Clients.GraphQl;

internal abstract class ShopifyGraphApiClient
{
    private readonly IGraphQLClient _client;

    protected ShopifyGraphApiClient(string graphQlUrl, HttpMessageHandler messageHandler)
    {
        var opts = new GraphQLHttpClientOptions
        {
            EndPoint = new Uri(graphQlUrl),
            HttpMessageHandler = messageHandler
        };

        var client = new GraphQLHttpClient(opts, new NewtonsoftJsonSerializer());
        _client = client;
    }

    public Task<GraphQLResponse<T>> RunQueryAsync<T>(string query, object? variables) where T : class
    {
        return RunQueryAsync<T>(new GenericGraphQlQuery(query, variables));
    }

    public async Task<GraphQLResponse<T>> RunQueryAsync<T>(IGraphQlQuery payload) where T : class
    {
        var graphQlRequest = payload.ToGraphQlRequest();
        try
        {
            var response = await _client.SendQueryAsync<T>(graphQlRequest);
            return response;
        }
        catch (GraphQLHttpRequestException ex)
        {
            throw new ShopifyApiException(ex.Message, ex.StatusCode, ex);
        }
        catch (Exception ex)
        {
            throw new ShopifyApiException(ex.Message, ex);
        }
    }

    public Task<GraphQLResponse<T>> RunMutationAsync<T>(string mutation, object? variables) where T : class
    {
        return RunMutationAsync<T>(new GenericGraphQlMutation(mutation, variables));
    }

    public async Task<GraphQLResponse<T>> RunMutationAsync<T>(IGraphQlMutation payload) where T : class
    {
        var graphQlRequest = payload.ToGraphQlRequest();
        try
        {
            var response = await _client.SendMutationAsync<T>(graphQlRequest);
            return response;
        }
        catch (GraphQLHttpRequestException ex)
        {
            throw new ShopifyApiException(ex.Message, ex.StatusCode, ex);
        }
        catch (Exception ex)
        {
            throw new ShopifyApiException(ex.Message, ex);
        }
    }
}