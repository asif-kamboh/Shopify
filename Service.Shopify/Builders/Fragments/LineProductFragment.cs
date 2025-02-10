using Service.Shopify.Requests.GraphQl;

namespace Service.Shopify.Builders.Fragments;

public sealed class LineProductFragment : GraphQlFragment
{
    public LineProductFragment(string name) : base(name)
    {
        AddFields(new[] {"id", "title", "handle"});
        AddFragment(new GraphQlNodesFragment<ImageFragment>("images", new GraphQlConnectionArgs {First = 1}));
        AddFragment(new TranslationsFragment("ar"));
    }
}