using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Builders.Fragments;

public sealed class LineVariantFragment : GraphQlFragment
{
    public LineVariantFragment(string name) : base(name)
    {
        AddFields(new[] {"id", "title", "weight"});
        AddFragment(new ImageFragment());
    }
}