using Refit;

namespace ScientificBit.Shopify.Requests;

public class CustomersQueryParams : AdminApiQueryParams
{
    private readonly IDictionary<string, string> _queryParams;

    public CustomersQueryParams() : this(new Dictionary<string, string>())
    {
    }

    public CustomersQueryParams(string email) : this(new Dictionary<string, string> { ["email"] = email })
    {
    }

    public CustomersQueryParams(IDictionary<string, string>? filters)
    {
        if (filters is null)
        {
            _queryParams = new Dictionary<string, string>();
        }
        else
        {
            _queryParams = new Dictionary<string, string>(filters);
        }
        this.Fields = "id,email,phone,firstName,lastName,state";
    }

    [AliasAs("query")]
    public string? Query => GetQuery();

    private string? GetQuery()
    {
        if (_queryParams.Any())
        {
            return string.Join(",", _queryParams.Select(kv => $"{kv.Key}:{kv.Value}"));
        }
        return null;
    }
}