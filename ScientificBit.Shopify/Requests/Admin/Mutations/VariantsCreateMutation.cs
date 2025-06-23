using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Requests.Admin.Mutations;

public class VariantsCreateMutation : GraphQlMutationBase
{

    protected override string MutationTemplate =>
        """
        mutation ProductVariantsCreate($productId: ID!, $variants: [ProductVariantsBulkInput!]!) {
                productVariantsBulkCreate(productId: $productId, variants: $variants) {
                    productVariants { id title }
                    userErrors { field message }
                }
            }
        """;
}