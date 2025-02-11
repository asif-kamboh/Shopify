using Service.Shopify.Enums;

namespace Service.Shopify.Requests.GraphQl;

public class GraphQlCreatedAtQueryStringParam
{
    public DateTime? CreatedAt { get; set; }

    public GraphQlRangeQueryParamOperator Op { get; set; } = GraphQlRangeQueryParamOperator.Equal;

    public override string ToString()
    {
        return $"created_at:{Op}{CreatedAt?.ToString("yyyy-MM-ddTHH:mm:ss")}";
    }
}