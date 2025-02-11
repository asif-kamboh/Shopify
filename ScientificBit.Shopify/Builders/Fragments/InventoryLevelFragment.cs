using ScientificBit.Shopify.Requests.Admin.Args;
using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Builders.Fragments;

/// <summary>
/// Requires `read_locations` access scope",
/// </summary>
public sealed class InventoryLevelFragment : GraphQlFragment
{
    public InventoryLevelFragment(string name, InventoryLevelArgs args) : base(name, args)
    {
        AddFields(new[] {"id", "updatedAt"});
        AddFragment(new ShopifyIdFragment("location"));

        var quantityArgs = new InventoryLevelQuantityArgs("available", "on_hand");
        AddFragment(new InventoryLevelQuantityFragment("quantities", quantityArgs));
    }
}