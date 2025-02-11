using GraphQL;
using Service.Shopify.Requests.Admin.Projections;
using Service.Shopify.Requests.GraphQl;

namespace Service.Shopify.Requests.Admin.Queries;

internal class DiscountNodeGetByIdQuery : GraphQlQueryBase
{
    private readonly DiscountCodeBasicProjection _projection;

    public DiscountNodeGetByIdQuery()
    {
        _projection = new DiscountCodeBasicProjection(0, null);
    }

    public override GraphQLRequest ToGraphQlRequest()
    {
        var query = $@"query getDiscountCodeNode($id: ID!) {{
            codeDiscountNode (id: $id) {{
                id
                { _projection }
            }}
        }}";
        return new GraphQLRequest {Variables = Variables, Query = query};
    }
}