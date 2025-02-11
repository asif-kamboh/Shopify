using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Builders.Fragments;

public sealed class ImageFragment : GraphQlFragment
{
    public ImageFragment() : this("image")
    {
    }

    public ImageFragment(string name) : base(name)
    {
        AddFields(new[] {"url", "altText"});
    }
}