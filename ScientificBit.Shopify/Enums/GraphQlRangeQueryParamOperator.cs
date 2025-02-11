namespace ScientificBit.Shopify.Enums;

public class GraphQlRangeQueryParamOperator
{
    private readonly string _op;

    private GraphQlRangeQueryParamOperator(string op)
    {
        _op = op;
    }

    public override string ToString()
    {
        return _op;
    }

    public static readonly GraphQlRangeQueryParamOperator Equal = new ("");

    public static readonly GraphQlRangeQueryParamOperator LessThan = new ("<");

    public static readonly GraphQlRangeQueryParamOperator LessThanOrEquals = new ("<=");

    public static readonly GraphQlRangeQueryParamOperator GreaterThan = new (">");

    public static readonly GraphQlRangeQueryParamOperator GreaterThanOrEquals = new (">=");
}