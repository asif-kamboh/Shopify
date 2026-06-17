using ScientificBit.Shopify.Builders.Fragments;
using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Requests.Admin.Mutations;

public class DraftOrderCreateMutation : GraphQlMutationBase
{
    protected override string MutationTemplate
    {
        get
        {
            var fragment = new DraftOrderFragment();
            fragment.AddFields(new[]
            {
                "id", "name", "status", "email", "phone",
                "tags", "currencyCode", "invoiceUrl",
                "taxExempt", "taxesIncluded",
                "createdAt", "updatedAt", "completedAt", "invoiceSentAt"
            });

            fragment.AddFragment(new MoneyBagFragment("subtotalPriceSet"));
            fragment.AddFragment(new MoneyBagFragment("totalPriceSet"));
            fragment.AddFragment(new MoneyBagFragment("totalTaxSet"));
            fragment.AddFragment(new MoneyBagFragment("totalShippingPriceSet"));
            fragment.AddFragment(new CustomerFragment("customer"));
            fragment.AddFragment(new AddressFragment("shippingAddress"));
            fragment.AddFragment(new AddressFragment("billingAddress"));

            return
                $$"""
                  mutation draftOrderCreate($input: DraftOrderInput!) {
                          result:draftOrderCreate(input: $input) {
                              data:{{fragment}}
                              {{new UserErrorsFragment()}}
                          }
                      }
                  """;
        }
    }
//     protected override string MutationTemplate =>
//         $$"""
//           mutation draftOrderCreate($input: DraftOrderInput!) {
//                   result:draftOrderCreate(input: $input) {
//                       data:{{new ShopifyIdFragment("draftOrder")}}
//                       {{new UserErrorsFragment()}}
//                   }
//               }
//           """;
}