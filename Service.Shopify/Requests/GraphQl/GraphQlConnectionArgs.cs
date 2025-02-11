namespace Service.Shopify.Requests.GraphQl;

/// <summary>
/// Node connections arguments
/// </summary>
public class GraphQlConnectionArgs : GraphQlQueryArgs
{
    /// <summary>
    /// First n objects
    /// </summary>
    public int? First { get; set; }

    /// <summary>
    /// Last n objects
    /// </summary>
    public int? Last { get; set; }

    /// <summary>
    /// Reverse sort
    /// </summary>
    public bool? Reverse { get; set; }

    /// <summary>
    /// Before cursor
    /// </summary>
    public string? Before { get; set; }

    /// <summary>
    /// After cursor
    /// </summary>
    public string? After { get; set; }
}