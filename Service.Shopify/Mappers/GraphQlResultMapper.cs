using GraphQL;
using Service.Shopify.Models.Base;
using Service.Shopify.Views;

namespace Service.Shopify.Mappers;

internal static class GraphQlResultMapper
{
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

    private static string? GetUserError(IList<AdminApiResponse.UserError>? userErrors)
    {
        return userErrors?.FirstOrDefault()?.Message;
    }

    private static string[]? GetGraphQlErrors(GraphQLError[]? graphQlErrors)
    {
        return graphQlErrors?.Select(e => e.Message).ToArray();
    }
}