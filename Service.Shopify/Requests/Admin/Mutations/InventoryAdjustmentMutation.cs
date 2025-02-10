using GraphQL;
using Service.Shopify.Requests.GraphQl;

namespace Service.Shopify.Requests.Admin.Mutations;

public class InventoryAdjustmentMutation : GraphQlMutationBase
{
    private const string Mutation = @"mutation inventoryAdjustQuantities($input: InventoryAdjustQuantitiesInput!) {
        inventoryAdjustQuantities(input: $input) {
            userErrors { code field message }
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