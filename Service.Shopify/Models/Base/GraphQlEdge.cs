namespace Service.Shopify.Models.Base;

public class GraphQlEdge<TNode> where TNode : new()
{
    public TNode? Node { get; set; }

    public string? Cursor { get; set; }
}