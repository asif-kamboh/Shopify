namespace ScientificBit.Shopify.Requests.GraphQl;

internal class GenericGraphQlMutation : GenericGraphQlRequest, IGraphQlMutation
{
    public GenericGraphQlMutation(string mutation, object? variables) : base(mutation, variables)
    {
    }
}