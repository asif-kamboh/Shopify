using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Builders.Fragments;

public sealed class MetafieldFragment : GraphQlFragment
{
    public MetafieldFragment(string? name, MetafieldQueryArgs? args = null)
        : base(name ?? "metafield", args)
    {
        AddFields(new[] {"id", "key", "value", "type", "description", "namespace"});
    }
}