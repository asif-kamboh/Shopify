namespace Service.Shopify.Models;

public class OptionCreateInput
{
    public string Name { get; set; } = string.Empty;

    public int Position { get; set; }

    public IList<OptionValueCreateInput> Values { get; set; } = new List<OptionValueCreateInput>();

    public LinkedMetafieldCreateInput? LinkedMetafield { get; set; }
}