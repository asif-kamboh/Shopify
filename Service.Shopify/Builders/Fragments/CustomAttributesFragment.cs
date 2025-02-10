using Service.Shopify.Requests.GraphQl;

namespace Service.Shopify.Builders.Fragments;

public sealed class CustomAttributesFragment : GraphQlFragment
{
    public CustomAttributesFragment(string name, IGraphQlQueryArgs? args = null) : base(name, args)
    {
        AddFields(new[] {"key", "value"});
    }
}