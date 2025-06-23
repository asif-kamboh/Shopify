namespace ScientificBit.Shopify.Requests.GraphQl;

public interface IGraphQlFragment
{
    string Name { get; }

    IList<IGraphQlFragment> Fragments { get; }

    IGraphQlQueryArgs? Args { get; }
}

public class GraphQlFragment : IGraphQlFragment
{
    public string Name { get; }

    public IGraphQlQueryArgs? Args { get; }

    public IList<IGraphQlFragment> Fragments => _fragments.ToList();

    private readonly List<IGraphQlFragment> _fragments = new ();

    public GraphQlFragment(string name, IGraphQlQueryArgs? args = null)
    {
        Args = args;

        name = name.Trim();
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException("Fragment name cannot be empty");
        }
        Name = name;
    }

    public virtual void AddField(string field)
    {
        AddFragment(new GraphQlFieldFragment(field));
    }

    public virtual void AddFields(IEnumerable<string> fields)
    {
        foreach (var field in fields)
        {
            AddFragment(new GraphQlFieldFragment(field));
        }
    }

    public virtual void AddFragment(IGraphQlFragment fragment)
    {
        var fragmentName = fragment.Name.Trim();
        // Validate fragment
        if (string.IsNullOrEmpty(fragmentName.Trim()))
        {
            throw new ArgumentException("Fragment name cannot be empty.");
        }
        // Remove existing fragment with the same name
        var index = _fragments.FindIndex(f => f.Name == fragmentName);
        if (index >= 0) _fragments.RemoveAt(index);

        _fragments.Add(fragment);
    }

    public virtual void AddFragments(IEnumerable<IGraphQlFragment> fragments)
    {
        foreach (var fragment in fragments)
        {
            AddFragment(fragment);
        }
    }

    public override string ToString()
    {
        var args = Args?.ToString();
        var name = !string.IsNullOrEmpty(args) ? $"{Name.Trim()}({args})" : Name.Trim();
        var fragmentStr = SerializedFragments();
        return !string.IsNullOrEmpty(fragmentStr) ? $"{name} {fragmentStr}".Trim() : "";
    }

    protected string SerializedFragments()
    {
        var tokens = _fragments.Select(f => f.ToString() ?? "").ToList();
        var fragmentStr = tokens.Any() ? $"{{ {string.Join(" ", tokens)} }}" : "";
        return fragmentStr;
    }
}