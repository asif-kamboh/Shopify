namespace ScientificBit.Shopify.Models.Base;

public class GraphQlPageInfo
{
    public bool HasPreviousPage { get; set; }

    public bool HasNextPage { get; set; }

    public string? StartCursor { get; set; } = default!;

    public string? EndCursor { get; set; } = default!;
}