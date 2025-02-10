using Service.Shopify.Models.Base;

namespace Service.Shopify.Views;

public abstract class GraphQlResult
{
    public string? Error { get; set; }

    public string[]? GraphQlErrors { get; set; }

    public bool HasErrors => !string.IsNullOrEmpty(Error) || GraphQlErrors is {Length: > 0};
}

public class GraphQlResult<TDocument> : GraphQlResult where TDocument : new ()
{
    public TDocument? Data { get; set; }
}

public class GraphQlResults<TDocument> : GraphQlResult where TDocument : new ()
{
    public IList<TDocument> Data { get; set; } = new List<TDocument>();

    public GraphQlPageInfo? PageInfo { get; set; }
}