using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Builders.Fragments;

public sealed class CustomerFragment : GraphQlFragment
{
    public CustomerFragment(string name, IGraphQlQueryArgs? args = null) : base(name, args)
    {
        var customerFields = new[]
        {
            "id", "displayName", "email", "phone", "firstName", "lastName"
        };
        AddFields(customerFields);
    }
}