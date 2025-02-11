using GraphQL;
using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Requests.Admin.Mutations;

internal class DiscountRedeemCodeDeleteMutation : GraphQlMutationBase
{
    const string Mutation = @"
        mutation bulkDeleteRedeemDiscountCode($discountId: ID!, $search: String) {
            discountCodeRedeemCodeBulkDelete (discountId: $discountId, search: $search) {
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