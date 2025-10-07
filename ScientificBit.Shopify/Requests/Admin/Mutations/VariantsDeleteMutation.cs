using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Requests.Admin.Mutations;

public class VariantsDeleteMutation : GraphQlMutationBase
{
    protected override string MutationTemplate =>
        """
        mutation bulkDeleteProductVariants($productId: ID!, $variantsIds: [ID!]!) {
                productVariantsBulkDelete(productId: $productId, variantsIds: $variantsIds) {
                    userErrors { field message }
                }
            }
        """;
}