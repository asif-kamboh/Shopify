using Service.Shopify.Enums;

namespace Service.Shopify.Requests.GraphQl;

public class GraphQlIdQueryStringParam
{
    public long Id { get; set; }

    public GraphQlRangeQueryParamOperator Op { get; set; }

    public override string ToString()
    {
        return $"id:{Op}{Id}";
    }
}