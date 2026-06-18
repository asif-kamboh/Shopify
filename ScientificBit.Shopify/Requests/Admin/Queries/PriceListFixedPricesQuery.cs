using GraphQL;
using ScientificBit.Shopify.Requests.GraphQl;
using ScientificBit.Shopify.Utils;

namespace ScientificBit.Shopify.Requests.Admin.Queries;

internal class PriceListFixedPricesQuery : GraphQlQueryBase
{
    private const string Query =
        """
        query getContextualPrices($priceListId: ID!, $query: String!) {
            priceList(id: $priceListId) {
                id name currency
                prices(first: 100, query: $query) {
                    nodes {
                        variant { id }
                        price { amount currencyCode }
                    }
                }
            }
        }
        """;

    public PriceListFixedPricesQuery(string priceListId, IList<string> variantIds)
    {
        Variables = new { PriceListId = priceListId, Query = string.Concat("variant_id:", string.Join(" OR variant_id:", variantIds.Select(ShopifyUtils.GetNumericId))) };
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
