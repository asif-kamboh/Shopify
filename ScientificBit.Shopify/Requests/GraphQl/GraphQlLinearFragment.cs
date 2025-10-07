namespace ScientificBit.Shopify.Requests.GraphQl;

public class GraphQlLinearFragment : GraphQlFragment
{
    public GraphQlLinearFragment(string name, IEnumerable<string> fields, IGraphQlQueryArgs? args = null) : base(name, args)
    {
        base.AddFields(fields);
    }
}