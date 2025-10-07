using ScientificBit.Shopify.Builders.Fragments;
using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Requests.Admin.Mutations;

internal class DiscountCodeCreateMutation : GraphQlMutationBase
{
    protected override string MutationTemplate =>
        $$"""
          mutation discountCodeBasicCreate($basicCodeDiscount: DiscountCodeBasicInput!) {
                  discountCodeBasicCreate(basicCodeDiscount: $basicCodeDiscount) {
                    {{new ShopifyIdFragment("codeDiscountNode")}}
                    {{new UserErrorsFragment()}}
                  }
                }
          """;
}