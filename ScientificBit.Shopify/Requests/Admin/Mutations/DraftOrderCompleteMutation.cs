using ScientificBit.Shopify.Builders.Fragments;
using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Requests.Admin.Mutations;

public class DraftOrderCompleteMutation : GraphQlMutationBase
{
    protected override string MutationTemplate =>
        $$"""
          mutation draftOrderComplete($id: ID!, $paymentPending: Boolean!) {
              result:draftOrderComplete(id: $id, paymentPending: $paymentPending) {
                  data:{{new DraftOrderFragment()}}
                  {{new UserErrorsFragment()}}
              }
          }
          """;
}