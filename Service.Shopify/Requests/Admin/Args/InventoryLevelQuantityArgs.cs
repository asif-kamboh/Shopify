using Service.Shopify.Requests.GraphQl;

namespace Service.Shopify.Requests.Admin.Args;

public class InventoryLevelQuantityArgs : IGraphQlQueryArgs
{
    private readonly IList<string> _names;

    public InventoryLevelQuantityArgs() : this("available")
    {
    }

    public InventoryLevelQuantityArgs(params string[] names)
    {
        _names = names.ToList();
    }

    public override string ToString()
    {
        // names: [""available"", ""on_hand""])
        if (!_names.Any()) _names.Add("available");
        var names = string.Join(", ", _names.Select(n => $"\"{n}\""));
        return $"names: [{names}]";
    }
}