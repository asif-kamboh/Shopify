namespace Service.Shopify.Requests.GraphQl;

public sealed class PageInfoFragment : GraphQlFragment
{
    public PageInfoFragment() : this("pageInfo")
    {
    }

    public PageInfoFragment(string name) : base(name)
    {
        AddFields(new []{"hasNextPage", "hasPreviousPage", "startCursor", "endCursor"});
    }
}