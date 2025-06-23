using ScientificBit.Shopify.Enums;

namespace ScientificBit.Shopify.Requests.GraphQl;

public class GraphQlIdQueryStringParam
{
    public long Id { get; set; }

    public GraphQlRangeQueryParamOperator Op { get; set; } = GraphQlRangeQueryParamOperator.Equal;

    public override string ToString()
    {
        return $"id:{Op}{Id}";
    }
}