using ScientificBit.Shopify.Builders.Fragments;
using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Requests.Admin.Mutations;

public class DraftOrderCreateMutation : GraphQlMutationBase
{
    protected override string MutationTemplate =>
        $$"""
          mutation draftOrderCreate($input: DraftOrderInput!) {
                  result:draftOrderCreate(input: $input) {
                      data:{{new ShopifyIdFragment("draftOrder")}}
                      {{new UserErrorsFragment()}}
                  }
              }
          """;
}