using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Requests.Admin.Mutations;

internal class PriceListFixedPricesAddMutation : GraphQlMutationBase
{
    protected override string MutationTemplate =>
        """
        mutation updateMarketPrice($priceListId: ID!, $prices: [PriceListPriceInput!]!) {
            result:priceListFixedPricesAdd(priceListId: $priceListId, prices: $prices) {
                data:prices {
                    variant { id }
                    price { amount currencyCode }
                }
                userErrors { field message }
            }
        }
        """;
}