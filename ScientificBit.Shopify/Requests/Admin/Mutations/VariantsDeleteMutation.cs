using GraphQL;
using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Requests.Admin.Mutations;

public class VariantsDeleteMutation : GraphQlMutationBase
{
    private const string Mutation = @"mutation bulkDeleteProductVariants($productId: ID!, $variantsIds: [ID!]!) {
        productVariantsBulkDelete(productId: $productId, variantsIds: $variantsIds) {
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