using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Requests.Admin.Mutations;

public class MetafieldsSetMutation : GraphQlMutationBase
{
    protected override string MutationTemplate =>
        """
        mutation MetafieldsSet($metafields: [MetafieldsSetInput!]!) {
            result:metafieldsSet(metafields: $metafields) {
                data:metafields {
                    key namespace value
                }
                userErrors { field message code }
            }
        }
        """;
}