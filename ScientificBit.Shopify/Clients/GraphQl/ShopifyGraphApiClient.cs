using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ScientificBit.Shopify.Exceptions;
using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Clients.GraphQl;

internal abstract class ShopifyGraphApiClient
{
    private readonly string _graphQlUrl;
    private readonly string _authHeaderName;
    private readonly string _authToken;

    protected ShopifyGraphApiClient(string graphQlUrl, string authHeaderName, string authToken)
    {
        _graphQlUrl = graphQlUrl;
        _authHeaderName = authHeaderName;
        _authToken = authToken;
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
            using var client = GetClient();
            var response = await client.SendQueryAsync<T>(graphQlRequest);
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
            using var client = GetClient();
            var response = await client.SendMutationAsync<T>(graphQlRequest);
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

    private GraphQLHttpClient GetClient()
    {
        var opts = new GraphQLHttpClientOptions
        {
            EndPoint = new Uri(_graphQlUrl),
            HttpMessageHandler = new GraphQlApiMessageHandler(_authHeaderName,_authToken)
        };

        return new GraphQLHttpClient(opts, new NewtonsoftJsonSerializer
        {
            JsonSerializerSettings =
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
            }
        });
    }
}

internal class GraphQlApiMessageHandler : HttpClientHandler
{
    private readonly string _authHeaderName;
    private readonly string _authToken;

    public GraphQlApiMessageHandler(string authHeaderName, string authToken)
    {
        _authHeaderName = authHeaderName;
        _authToken = authToken;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        request.Headers.Add(_authHeaderName, _authToken);

        // Proceed with the request
        return await base.SendAsync(request, cancellationToken);
    }
}