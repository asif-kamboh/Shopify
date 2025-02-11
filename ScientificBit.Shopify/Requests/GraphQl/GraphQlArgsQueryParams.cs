namespace ScientificBit.Shopify.Requests.GraphQl;

public abstract class GraphQlArgsQueryParams
{
    protected abstract IList<string> SerializeParams();

    public override string ToString()
    {
        var tokens = SerializeParams();
        return tokens.Count > 0 ? string.Join(" AND ", tokens) : string.Empty;
    }
}