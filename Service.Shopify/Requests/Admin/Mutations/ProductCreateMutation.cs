using GraphQL;
using Service.Shopify.Requests.GraphQl;

namespace Service.Shopify.Requests.Admin.Mutations;

public class ProductCreateMutation : GraphQlMutationBase
{
    private const string Mutation = @"mutation productCreate($product: ProductCreateInput) {
        productCreate(input: $input, media: $media, product: $product) {
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