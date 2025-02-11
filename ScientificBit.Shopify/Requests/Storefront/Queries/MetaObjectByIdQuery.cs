using GraphQL;
using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Requests.Storefront.Queries;

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