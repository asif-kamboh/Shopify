using Service.Shopify.Requests.Admin.Args;
using Service.Shopify.Requests.GraphQl;

namespace Service.Shopify.Builders.Fragments;

public sealed class InventoryLevelQuantityFragment : GraphQlFragment
{
    public InventoryLevelQuantityFragment(string name, InventoryLevelQuantityArgs args) : base(name, args)
    {
        AddFields(new[] {"name", "quantity"});
    }
}