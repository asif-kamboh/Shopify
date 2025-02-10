namespace Service.Shopify.Requests.GraphQl;

public sealed class GraphQlFieldFragment : GraphQlFragment
{
    public GraphQlFieldFragment(string name) : base(name, null)
    {
    }

    public override string ToString()
    {
        return Name;
    }
}