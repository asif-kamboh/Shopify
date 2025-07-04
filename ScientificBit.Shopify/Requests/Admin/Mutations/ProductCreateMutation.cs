using GraphQL;
using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Requests.Admin.Mutations;

public class ProductCreateMutation : GraphQlMutationBase
{
    private const string Mutation = @"mutation productCreate($product: ProductCreateInput, $media:[CreateMediaInput!]) {
        productCreate(product: $product, media: $media) {
            product { id title }
            userErrors { field message }
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