using ScientificBit.Shopify.Models.Base;

namespace ScientificBit.Shopify.Views;

public abstract class GraphQlResultBase
{
    public string? Error { get; set; }

    public string[]? GraphQlErrors { get; set; }

    public bool HasErrors => !string.IsNullOrEmpty(Error) || GraphQlErrors is {Length: > 0};
}

public class GraphQlResult<TDocument> : GraphQlResultBase where TDocument : new ()
{
    public TDocument? Data { get; set; }
}

public class GraphQlResults<TDocument> : GraphQlResultBase where TDocument : new ()
{
    public IList<TDocument> Data { get; set; } = new List<TDocument>();

    public GraphQlPageInfo? PageInfo { get; set; }
}