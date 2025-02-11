using GraphQL;
using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Requests.Admin.Mutations;

internal class DiscountRedeemCodeAddMutation : GraphQlMutationBase
{
    private const string Mutation = @"
        mutation discountRedeemCodeBulkAdd($discountId: ID!, $codes: [DiscountRedeemCodeInput!]!) {
            discountRedeemCodeBulkAdd(discountId: $discountId, codes: $codes) {
                userErrors { field message }
            }
        }";

    public override GraphQLRequest ToGraphQlRequest()
    {
        return new GraphQLRequest
        {
            Variables = Variables,
            Query = Mutation
        };
    }
}