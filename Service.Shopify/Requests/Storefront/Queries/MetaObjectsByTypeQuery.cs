using GraphQL;
using Service.Shopify.Requests.GraphQl;

namespace Service.Shopify.Requests.Storefront.Queries;

internal class MetaObjectsByTypeQuery : GraphQlQueryBase
{
    private const string Query = @"
        query getMetafieldObjects($type: String!) {
            metaobjects(first: 100, type: $type) {
                nodes {
                    id
                    handle
                    fields {
                        key
                        value
                    }
                }
            }
        }";

    public MetaObjectsByTypeQuery(string type)
    {
        Variables = new {Type = type};
    }

    public override GraphQLRequest ToGraphQlRequest()
    {
        return new GraphQLRequest
        {
            Query = Query,
            Variables = Variables
        };
    }
}