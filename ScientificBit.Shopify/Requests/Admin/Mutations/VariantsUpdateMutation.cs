using ScientificBit.Shopify.Builders.Fragments;
using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Requests.Admin.Mutations;

internal class VariantsUpdateMutation : GraphQlMutationBase
{
    protected override string MutationTemplate =>
        $$"""
          mutation ProductVariantsBulkUpdate($productId: ID!, $variants: [ProductVariantsBulkInput!]!) {
              productVariantsBulkUpdate(productId: $productId, variants: $variants) {
                  {{new VariantFragment("productVariants")}}
                  userErrors { field message }
              }
          }
          """;
}
