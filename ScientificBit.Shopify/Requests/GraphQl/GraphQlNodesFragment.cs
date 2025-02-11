namespace ScientificBit.Shopify.Requests.GraphQl;

public class GraphQlNodesFragment<TNodeFragment> : GraphQlConnectionFragment<TNodeFragment>
    where TNodeFragment : GraphQlFragment
{
    public GraphQlNodesFragment(string name, GraphQlConnectionArgs args) : base(name, false, args)
    {
    }
}