using GraphQL;
using Service.Shopify.Requests.GraphQl;

namespace Service.Shopify.Requests.Storefront.Queries;

internal class MetaObjectByIdQuery : GraphQlQueryBase
{
    private const string Query = @"
        query getMetaObject($gid: ID!) {
            metaobject(id: $gid) {
                id
                handle
                fields { value key }
            }
        }";

    public MetaObjectByIdQuery(string metaObjectId)
    {
        Variables = new {Gid = metaObjectId};
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