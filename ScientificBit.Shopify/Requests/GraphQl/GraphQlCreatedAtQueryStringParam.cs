using ScientificBit.Shopify.Enums;

namespace ScientificBit.Shopify.Requests.GraphQl;

public class GraphQlCreatedAtQueryStringParam
{
    public DateTime? CreatedAt { get; set; }

    public GraphQlRangeQueryParamOperator Op { get; set; } = GraphQlRangeQueryParamOperator.Equal;

    public override string ToString()
    {
        return $"created_at:{Op}{CreatedAt?.ToString("yyyy-MM-ddTHH:mm:ss")}";
    }
}