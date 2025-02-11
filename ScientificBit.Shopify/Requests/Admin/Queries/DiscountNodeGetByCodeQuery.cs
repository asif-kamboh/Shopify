using GraphQL;
using ScientificBit.Shopify.Requests.Admin.Projections;
using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Requests.Admin.Queries;

internal class DiscountNodeGetByCodeQuery : GraphQlQueryBase
{
    private readonly DiscountCodeBasicProjection _projection;

    public DiscountNodeGetByCodeQuery() :this(0) 
    {
    }

    public DiscountNodeGetByCodeQuery(int codesCount, string? afterCursor = null)
    {
        _projection = new DiscountCodeBasicProjection(codesCount, afterCursor);
    }

    public override GraphQLRequest ToGraphQlRequest()
    {
        var query = $@"query getDiscountCodeByCode($code: String!) {{
            codeDiscountNodeByCode (code: $code) {{
                id
                { _projection }
            }}
        }}";
        return new GraphQLRequest {Variables = Variables, Query = query};
    }
}