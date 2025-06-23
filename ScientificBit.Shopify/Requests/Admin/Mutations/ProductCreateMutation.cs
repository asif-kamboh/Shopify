using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Requests.Admin.Mutations;

public class ProductCreateMutation : GraphQlMutationBase
{
    protected override string MutationTemplate =>
        """
        mutation productCreate($product: ProductCreateInput, $media:[CreateMediaInput!]) {
                productCreate(product: $product, media: $media) {
                    product { id title }
                    userErrors { field message }
                }
            }
        """;
}