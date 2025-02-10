using Service.Shopify.Requests.GraphQl;

namespace Service.Shopify.Builders.Fragments;

public sealed class LineVariantFragment : GraphQlFragment
{
    public LineVariantFragment(string name) : base(name)
    {
        AddFields(new[] {"id", "title", "weight"});
        AddFragment(new ImageFragment());
        AddFragment(new TranslationsFragment("ar"));
    }
}