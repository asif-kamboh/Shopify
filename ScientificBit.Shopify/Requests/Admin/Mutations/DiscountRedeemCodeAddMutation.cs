using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Requests.Admin.Mutations;

internal class DiscountRedeemCodeAddMutation : GraphQlMutationBase
{
    protected override string MutationTemplate =>
        """
                mutation discountRedeemCodeBulkAdd($discountId: ID!, $codes: [DiscountRedeemCodeInput!]!) {
                    discountRedeemCodeBulkAdd(discountId: $discountId, codes: $codes) {
                        userErrors { field message }
                    }
                }
        """;
}