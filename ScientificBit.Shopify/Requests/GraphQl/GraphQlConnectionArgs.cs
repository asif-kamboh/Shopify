namespace ScientificBit.Shopify.Requests.GraphQl;

/// <summary>
/// Node connections arguments
/// </summary>
public class GraphQlConnectionArgs : GraphQlQueryArgs
{
    private int? _first;
    private int? _last;
    private string? _after;
    private string? _before;

    /// <summary>
    /// First n objects
    /// </summary>
    public int? First {
        get => _first;
        set
        {
            _first = value;
            if (value != null) _last = null;
        }
    }

    /// <summary>
    /// Last n objects
    /// </summary>
    public int? Last
    {
        get => _last;
        set
        {
            _last = value;
            if (value != null) _first = null;
        }
    }

    /// <summary>
    /// Reverse sort
    /// </summary>
    public bool? Reverse { get; set; }

    /// <summary>
    /// Before cursor
    /// </summary>
    public string? Before
    {
        get => _before;
        set
        {
            _before = value;
            if (value != null) _after = null;
        }
    }

    /// <summary>
    /// After cursor
    /// </summary>
    public string? After
    {
        get => _after;
        set
        {
            _after = value;
            if (value != null) _before = null;
        }
    }
}