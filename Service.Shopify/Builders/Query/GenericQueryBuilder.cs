using System.Text;
using System.Text.RegularExpressions;
using Service.Shopify.Builders.Fragments;
using Service.Shopify.Requests.GraphQl;

namespace Service.Shopify.Builders.Query;

public class GenericQueryBuilder<TConnectionArgs> : GenericQueryBuilder where TConnectionArgs : GraphQlConnectionArgs, new()
{
    public TConnectionArgs ConnectionArgs
    {
        get
        {
            var args = Args as TConnectionArgs ?? new TConnectionArgs();
            Args ??= args;
            return args;
        }
    }

    public GenericQueryBuilder(string methodSignature, string resource, IEnumerable<string> fields, TConnectionArgs? args = null)
        : base(methodSignature, resource, fields, args)
    {
    }
}

public class GenericQueryBuilder
{
    private readonly string _methodSignature;
    private readonly string _resource;

    internal List<IGraphQlFragment> Fragments { get; } = new();

    public bool Pagination { get; set; }

    protected GraphQlConnectionArgs? Args { get; set; }

    public GenericQueryBuilder(string methodSignature, string resource, IEnumerable<string> fields, GraphQlConnectionArgs? args = null)
    {
        _methodSignature = methodSignature;
        _resource = resource;
        Args = args;
        foreach (var field in fields.Distinct())
        {
            Fragments.Add(new GraphQlFieldFragment(field));
        }
    }

    public virtual GraphQlQuery Build(object? variables = null)
    {
        // TODO: Validate variables

        var fragment = Pagination ? BuildEdgesQuery()
            : Args != null ? BuildNodesQuery()
            : BuildSimpleQuery();

        var query = $@"query {_methodSignature} {{
            {fragment.ToString()}
        }}";
        var formattedQuery = Format(query);
        return new GraphQlQuery
        {
            Query = formattedQuery,
            Variables = variables
        };
    }

    #region Helper methods

    private GraphQlFragment BuildSimpleQuery()
    {
        var fragment = new GraphQlFragment(_resource);
        fragment.AddFragments(Fragments);
        return fragment;
    }

    private GraphQlFragment BuildNodesQuery()
    {
        var args = Args ?? new GraphQlConnectionArgs {First = 10};
        var fragment = new GraphQlNodesFragment<GraphQlFragment>(_resource, args);
        fragment.AddFragments(Fragments);
        return fragment;
    }

    private GraphQlFragment BuildEdgesQuery()
    {
        var args = Args ?? new GraphQlConnectionArgs {First = 10};
        var fragment = new GraphQlEdgesFragment<GraphQlFragment>(_resource, args);
        fragment.AddFragments(Fragments);
        return fragment;
    }

    private static string Format(string query)
    {
        const int indentSize = 2; // Spaces to indent
        const int maxLineLength = 80; // Max characters per line
        var formatted = new StringBuilder();
        var indentLevel = 0;

        // Normalize spaces and newlines for the input query
        var normalizedQuery = query
            .Replace("\r\n", "\n")
            .Replace("\n", " ")
            .Replace("{", " { ")
            .Replace("}", " } ")
            .Replace(",", ", ")
            .Replace("  ", " ");

        // Using regex to remove multiple spaces and newlines
        normalizedQuery = Regex.Replace(normalizedQuery, @"\s+", " ").Trim();

        // Split the query into tokens using braces as delimiters
        var tokens = Regex.Split(normalizedQuery, @"(\{|\})").Select(t => t.Trim()).ToArray();

        foreach (var token in tokens)
        {
            if (string.IsNullOrWhiteSpace(token)) continue;

            if (token == "}")
            {
                indentLevel--; // Decrease indent level on closing brace
            }

            if (token == "{")
            {
                // formatted.AppendLine(" {");
                formatted.Remove(formatted.Length - 1, 1);
                formatted.AppendLine(" {");
                indentLevel++; // Increase indent level after opening brace
            }
            else
            {
                // Add the token with proper indentation
                var currentIndentation = new string(' ', indentLevel * indentSize);

                // Check if we can fit this line as a single line (length-wise)
                var fields = token.Split(' ').Where(t => !string.IsNullOrWhiteSpace(t)).ToArray();
                var singleLine = string.Join(" ", fields);

                if (singleLine.Length + currentIndentation.Length <= maxLineLength)
                {
                    formatted.AppendLine(currentIndentation + singleLine);
                }
                else
                {
                    // Break the fields into multiple lines
                    foreach (var field in fields)
                    {
                        formatted.AppendLine(currentIndentation + field);
                    }
                }
            }
        }

        // Final cleanup to ensure extra spaces or lines are removed
        var result = formatted.ToString().Trim();
        return result;
    }

    #endregion
}

public static class GenericQueryBuilderExtensions
{
    public static TBuilder AddField<TBuilder>(this TBuilder builder, string field) where TBuilder : GenericQueryBuilder
    {
        return builder.AddFragment(new GraphQlFieldFragment(field));
    }

    public static TBuilder AddSingularFields<TBuilder>(this TBuilder builder, IEnumerable<string> fields)
        where TBuilder : GenericQueryBuilder
    {
        foreach (var field in fields)
        {
            builder.AddField(field);
        }
        return builder;
    }

    public static TBuilder AddTranslations<TBuilder>(this TBuilder builder, string locale, string? alias = null) where TBuilder : GenericQueryBuilder
    {
        var field = string.IsNullOrEmpty(alias) ? "translations" : $"{alias}: translations";
        var args = new TranslationQueryArgs {Locale = locale};
        return builder.AddFragment(new TranslationsFragment(field, args));
    }

    public static TBuilder AddMetafield<TBuilder>(this TBuilder builder, string ns, string key, string? alias)  where TBuilder : GenericQueryBuilder
    {
        var args = new MetafieldQueryArgs { Namespace = ns, Key = key };
        return builder.AddFragment(new MetafieldFragment(alias, args));
    }

    public static TBuilder AddMetafields<TBuilder>(this TBuilder builder, string ns, int count = 10)  where TBuilder : GenericQueryBuilder
    {
        var args = new MetafieldsQueryArgs
        {
            Namespace = ns,
            First = count
        };
        return builder.AddFragment(new MetafieldsFragment("metafields", args));
    }

    public static TBuilder AddNodes<TBuilder>(this TBuilder builder, string field, IEnumerable<string> innerFields,
        GraphQlConnectionArgs? args) where TBuilder : GenericQueryBuilder
    {
        args ??= new GraphQlConnectionArgs {First = 1};
        var nodesFragment = new GraphQlNodesFragment<GraphQlFragment>(field, args);
        nodesFragment.AddFields(innerFields);
        return builder.AddFragment(nodesFragment);
    }

    public static TBuilder AddFragment<TBuilder>(this TBuilder builder, IGraphQlFragment fragment)
        where TBuilder : GenericQueryBuilder
    {
        var fragmentName = fragment.Name.Split(" ")[0];
        var index = builder.Fragments.FindIndex(f => f.Name.Split(" ")[0] == fragmentName);
        // Remove existing item, if any
        if (index >= 0) builder.Fragments.RemoveAt(index);

        builder.Fragments.Add(fragment);
        return builder;
    }
}