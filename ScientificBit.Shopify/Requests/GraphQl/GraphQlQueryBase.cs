namespace ScientificBit.Shopify.Requests.GraphQl;

internal abstract class GraphQlQueryBase : GraphQlRequestBase, IGraphQlQuery
{
    private readonly string[] _metafieldKeys = {"id", "key", "value", "type"};

    private readonly List<string> _fields = new ();

    protected string SerializedFields => string.Join("\n", _fields);

    protected void AddFields(IEnumerable<string> fields)
    {
        _fields.AddRange(fields.Distinct());
    }

    public void AddMetafields(string ns, int count = 10)
    {
        var args = new MetafieldsQueryArgs
        {
            Namespace = ns,
            First = count
        };
        AddCompositeField("metafields", _metafieldKeys, args);
    }

    public void AddMetafield(string ns, string key, string? alias)
    {
        var field = string.IsNullOrEmpty(alias) ? "metafield" : $"{alias}: metafield";
        var args = new MetafieldQueryArgs { Namespace = ns, Key = key };
        AddCompositeField(field, _metafieldKeys, args);
    }

    public void AddField(string field)
    {
        AddCompositeField(field, new string[] {}, null);
    }

    public void AddNodes(string field, IEnumerable<string> innerFields, GraphQlConnectionArgs? args)
    {
        AddCompositeField(field, innerFields, args, "nodes");
    }

    public void AddCompositeField(string field, IEnumerable<string> innerFields, IGraphQlQueryArgs? args, string? connection = null)
    {
        if (string.IsNullOrEmpty(field)) throw new ArgumentException("field can't be empty");

        var index = _fields.FindIndex(f => f.Split(" ")[0] == field);
        // Remove existing item, if any
        if (index >= 0) _fields.RemoveAt(index);

        var tokens = new List<string> {field};
        var argsString = args?.ToString();
        if (!string.IsNullOrEmpty(argsString))
        {
            tokens.Add($" ({argsString}) ");
        }

        var isNode = "nodes" == connection;
        var isEdge = "edges" == connection;

        if (isNode)
        {
            tokens.Add("{\nnodes");
        }
        else if (isEdge)
        {
            tokens.Add("{\nedges {\n node");
        }
        var documentFields = string.Join(" ", innerFields);
        if (!string.IsNullOrEmpty(documentFields))
        {
            tokens.Add("{ ");
            tokens.Add(documentFields);
            tokens.Add(" }");
        }

        if (isNode)
        {
            tokens.Add("}");
        }
        else if (isEdge)
        {
            tokens.Add("}\n}");
        }

        var fragment = string.Join("\n", tokens);
        _fields.Add(fragment);
    }

    public void AddTranslations(string locale, string? alias = null)
    {
        var field = string.IsNullOrEmpty(alias) ? "translations" : $"{alias}: translations";
        AddCompositeField(field, new[] {"key", "value", "locale"}, new TranslationQueryArgs {Locale = "ar"});
    }
}