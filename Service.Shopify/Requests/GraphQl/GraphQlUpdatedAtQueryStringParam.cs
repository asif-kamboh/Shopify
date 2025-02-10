using Service.Shopify.Enums;

namespace Service.Shopify.Requests.GraphQl;

public class GraphQlUpdatedAtQueryStringParam
{
    public DateTime? UpdatedAt { get; set; }

    public GraphQlRangeQueryParamOperator Op { get; set; } = GraphQlRangeQueryParamOperator.Equal;

    public override string ToString()
    {
        return $"updated_at:{Op}{UpdatedAt?.ToString("yyyy-MM-ddTHH:mm:ss")}";
    }
}