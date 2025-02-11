namespace ScientificBit.Shopify.Requests.GraphQl;

public class MetafieldQueryArgs : GraphQlQueryArgs
{
    public string? Namespace { get; set; }

    public string? Key { get; set; }
}

public class MetafieldsQueryArgs : GraphQlConnectionArgs
{
    public string? Namespace { get; set; }
}