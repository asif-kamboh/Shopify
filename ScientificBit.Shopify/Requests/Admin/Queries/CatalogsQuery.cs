using GraphQL;
using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Requests.Admin.Queries;

internal class CatalogsQuery : GraphQlQueryBase
{
    private const string Query =
        """
        query getCatalogs($query: String!) {
            catalogs(first: 1, type: MARKET, query: $query) {
                nodes {
                    id status
                    priceList { id name currency }
                }
            }
        }
        """;

    public CatalogsQuery(string query)
    {
        Variables = new { Query = query };
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
