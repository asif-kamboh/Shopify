using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Builders.Fragments;

public sealed class ProductOptionFragment : GraphQlFragment
{
    public ProductOptionFragment(string name, OptionsQueryArgs args) : base(name, args)
    {
        AddFields(new[] {"id", "name", "position", "values"});
    }
}