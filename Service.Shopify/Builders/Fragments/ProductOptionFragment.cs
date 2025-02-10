using Service.Shopify.Requests.GraphQl;

namespace Service.Shopify.Builders.Fragments;

public sealed class ProductOptionFragment : GraphQlFragment
{
    public ProductOptionFragment(string name, OptionsQueryArgs args) : base(name, args)
    {
        AddFields(new[] {"id", "name", "position", "values"});
    }
}