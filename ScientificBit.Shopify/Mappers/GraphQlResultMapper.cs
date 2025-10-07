using GraphQL;
using ScientificBit.Shopify.Models.Base;
using ScientificBit.Shopify.Views;

namespace ScientificBit.Shopify.Mappers;

internal static class GraphQlResultMapper
{
    public static GraphQlResult<TDocument> BuildResult<TDocument>(IGraphQLResponse gqlResponse, Func<GraphQlResult<TDocument>> fn)
        where TDocument : new()
    {
        try
        {
            return fn.Invoke();
        }
        catch (Exception)
        {
            return new GraphQlResult<TDocument> { GraphQlErrors = GetGraphQlErrors(gqlResponse.Errors) };
        }
    }

    public static GraphQlResults<TDocument> BuildResults<TDocument>(IGraphQLResponse gqlResponse, Func<GraphQlResults<TDocument>> fn)
        where TDocument : new()
    {
        try
        {
            return fn.Invoke();
        }
        catch (Exception)
        {
            return new GraphQlResults<TDocument> { GraphQlErrors = GetGraphQlErrors(gqlResponse.Errors) };
        }
    }

    public static GraphQlResult<TDocument> CreateResult<TDocument>(TDocument? data,
        IList<AdminApiResponse.UserError>? userErrors,
        GraphQLError[]? graphQlErrors) where TDocument : new ()
    {
        var result = new GraphQlResult<TDocument>
        {
            Data = data,
            Error = GetUserError(userErrors),
            GraphQlErrors = GetGraphQlErrors(graphQlErrors)
        };
        return result;
    }

    public static GraphQlResults<TDocument> CreateResult<TDocument>(IList<TDocument>? data,
        IList<AdminApiResponse.UserError>? userErrors,
        GraphQLError[]? graphQlErrors) where TDocument : new ()
    {
        var result = new GraphQlResults<TDocument>
        {
            Data = data ?? new List<TDocument>(),
            Error = GetUserError(userErrors),
            GraphQlErrors = GetGraphQlErrors(graphQlErrors)
        };
        return result;
    }

    public static GraphQlResults<TDocument> CreateResult<TDocument>(GraphQlConnection<TDocument>? data,
        IList<AdminApiResponse.UserError>? userErrors,
        GraphQLError[]? graphQlErrors) where TDocument : new ()
    {
        var result = new GraphQlResults<TDocument>
        {
            Data = data?.Documents ?? new List<TDocument>(),
            PageInfo = data?.PageInfo,
            Error = GetUserError(userErrors),
            GraphQlErrors = GetGraphQlErrors(graphQlErrors)
        };
        return result;
    }

    public static string? GetUserError(IList<AdminApiResponse.UserError>? userErrors)
    {
        return userErrors?.FirstOrDefault()?.Message;
    }

    private static string[]? GetGraphQlErrors(GraphQLError[]? graphQlErrors)
    {
        return graphQlErrors?.Select(e => e.Message).ToArray();
    }
}