using GraphQL;
using Service.Shopify.Requests.GraphQl;

namespace Service.Shopify.Requests.Admin.Queries;

internal class InventoryItemByIdQuery : GraphQlQueryBase
{
    private const string Query = @"
        query getInventoryItem($id: ID!) {
          inventoryItem(id: $id) {
              id
              sku
              requiresShipping
              variant {
                  id
                  sku
                  title
                  displayName
             }
        }
    }";

    public InventoryItemByIdQuery(string itemId)
    {
        Variables = new { Id = itemId };
    }

    public override GraphQLRequest ToGraphQlRequest()
    {
        return new GraphQLRequest
        {
            Query = Query,
            Variables = Variables
        };
    }
}