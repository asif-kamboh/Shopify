using GraphQL;

namespace ScientificBit.Shopify.Requests.GraphQl;

public abstract class GraphQlMutationBase : GraphQlRequestBase, IGraphQlMutation
{
    protected abstract string MutationTemplate { get; }

    public override GraphQLRequest ToGraphQlRequest()
    {
        return new GraphQLRequest
        {
            Variables = Variables,
            Query = MutationTemplate
        };
    }
}