using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Requests.Admin.Mutations;

public class MetafieldsDeleteMutation : GraphQlMutationBase
{
    protected override string MutationTemplate =>
        """
        mutation MetafieldsDelete($metafields: [MetafieldIdentifierInput!]!) {
            result:metafieldsDelete(metafields: $metafields) {
                data:deletedMetafields {
                    ownerId namespace key
                }
                userErrors { field message }
            }
        }
        """;
}