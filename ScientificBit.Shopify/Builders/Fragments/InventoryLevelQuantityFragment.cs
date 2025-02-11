using ScientificBit.Shopify.Requests.Admin.Args;
using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Builders.Fragments;

public sealed class InventoryLevelQuantityFragment : GraphQlFragment
{
    public InventoryLevelQuantityFragment(string name, InventoryLevelQuantityArgs args) : base(name, args)
    {
        AddFields(new[] {"name", "quantity"});
    }
}