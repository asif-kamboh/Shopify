using GraphQL;
using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Requests.Storefront.Queries;

internal class CartByIdQuery : GraphQlQueryBase
{
    private readonly IList<string> _metafieldKeys;
    private readonly string _metafieldsNamespace;

    public CartByIdQuery(string cartId, IEnumerable<string> metafieldKeys, string metafieldsNamespace = "default")
    {
        _metafieldKeys = metafieldKeys.ToList();
        _metafieldsNamespace = metafieldsNamespace;
        Variables = new {CartId = cartId};
    }

    public override GraphQLRequest ToGraphQlRequest()
    {
        var metafieldsFragment = BuildMetafieldsFragment();
        var query = @$"query cartQuery($cartId: ID!) {{
            cart(id: $cartId) {{
            id
            lines(first: 100) {{
                nodes {{
                  id
                  merchandise {{
                      ... on ProductVariant {{
                          product {{
                              id
                              title
                              {metafieldsFragment}
                          }}
                          id
                          title
                          {metafieldsFragment}
                      }}
                  }}
              }}
            }}
          }}
        }}";

        return new GraphQLRequest
        {
            Variables = Variables,
            Query = query
        };
    }

    private string BuildMetafieldsFragment()
    {
        if (!_metafieldKeys.Any()) return "";

        var identifiers = _metafieldKeys.Distinct().Select(key => $"{{namespace:\"{_metafieldsNamespace}\", key:\"{key}\"}}");
        return $@"metafields(identifiers:[{string.Join(",", identifiers)}]) {{
            id namespace key value
        }}";
    }
}