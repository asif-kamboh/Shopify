using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Requests.Admin.Mutations;

public class InventoryAdjustmentMutation : GraphQlMutationBase
{
    protected override string MutationTemplate =>
        """
        mutation inventoryAdjustQuantities($input: InventoryAdjustQuantitiesInput!) {
                inventoryAdjustQuantities(input: $input) {
                    userErrors { code field message }
                }
            }
        """;
}