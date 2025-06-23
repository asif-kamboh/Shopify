using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Builders.Fragments;

public sealed class UserErrorsFragment : GraphQlFragment
{
    public UserErrorsFragment() : base("userErrors")
    {
        AddFields(new[] { "field", "message" });
    }
}