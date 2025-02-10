namespace Service.Shopify.Models.Base;

public class GraphQlConnection<TNode> where TNode : new()
{
    public IList<TNode> Documents => Nodes ?? Edges?.Select(e => e.Node!).ToList() ?? new List<TNode>();

    public IList<TNode>? Nodes { get; set; }

    public IList<GraphQlEdge<TNode>>? Edges { get; set; }

    public GraphQlPageInfo? PageInfo { get; set; }
}