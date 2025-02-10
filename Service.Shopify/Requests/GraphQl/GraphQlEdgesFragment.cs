namespace Service.Shopify.Requests.GraphQl;

public sealed class GraphQlEdgesFragment<TNodeFragment> : GraphQlConnectionFragment<TNodeFragment>
    where TNodeFragment : GraphQlFragment
{
    public GraphQlEdgesFragment(string name, GraphQlConnectionArgs args) : base(name, true, args)
    {
    }
}