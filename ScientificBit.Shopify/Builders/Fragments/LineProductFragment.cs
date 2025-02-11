using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Builders.Fragments;

public sealed class LineProductFragment : GraphQlFragment
{
    public LineProductFragment(string name) : base(name)
    {
        AddFields(new[] {"id", "title", "handle"});
        AddFragment(new GraphQlNodesFragment<ImageFragment>("images", new GraphQlConnectionArgs {First = 1}));
        AddFragment(new TranslationsFragment("ar"));
    }
}