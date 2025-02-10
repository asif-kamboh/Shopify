using GraphQL;
using Service.Shopify.Requests.GraphQl;

namespace Service.Shopify.Requests.Admin.Mutations;

internal class DiscountCodeCreateMutation : GraphQlMutationBase
{
    const string Mutation = @"
        mutation discountCodeBasicCreate($basicCodeDiscount: DiscountCodeBasicInput!) {
            discountCodeBasicCreate(basicCodeDiscount: $basicCodeDiscount) {
              codeDiscountNode {
                  id 
              }
              userErrors {
                field
                code
                message
              }
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