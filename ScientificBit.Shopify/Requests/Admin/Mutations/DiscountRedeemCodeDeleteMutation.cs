using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Requests.Admin.Mutations;

internal class DiscountRedeemCodeDeleteMutation : GraphQlMutationBase
{
    protected override string MutationTemplate =>
        """
                mutation bulkDeleteRedeemDiscountCode($discountId: ID!, $search: String) {
                    discountCodeRedeemCodeBulkDelete (discountId: $discountId, search: $search) {
                        userErrors { field message }
                    }
                }
        """;
}