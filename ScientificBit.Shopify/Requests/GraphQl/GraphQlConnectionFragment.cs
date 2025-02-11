using System.Runtime.CompilerServices;

namespace ScientificBit.Shopify.Requests.GraphQl;

public class GraphQlConnectionFragment<TNodeFragment> : GraphQlFragment where TNodeFragment : GraphQlFragment
{
    private readonly GraphQlFragment _internalFragment;

    protected GraphQlConnectionFragment(string name, bool isEdge, GraphQlConnectionArgs? args = null) : base(name, args)
    {
        if (isEdge)
        {
            _internalFragment = CreateInternalFragment("node");
            var edgesFragment = new GraphQlFragment("edges");
            edgesFragment.AddFragment(_internalFragment);
            edgesFragment.AddField("cursor");
            base.AddFragment(edgesFragment);
            base.AddFragment(new PageInfoFragment("pageInfo"));
        }
        else
        {
            _internalFragment = CreateInternalFragment("nodes");
            base.AddFragment(_internalFragment);
        }
    }

    public override void AddField(string field)
    {
        _internalFragment.AddField(field);
    }

    public override void AddFields(IEnumerable<string> fields)
    {
        _internalFragment.AddFields(fields);
    }

    public override void AddFragment(IGraphQlFragment fragment)
    {
        _internalFragment.AddFragment(fragment);
    }

    public override void AddFragments(IEnumerable<IGraphQlFragment> fragments)
    {
        _internalFragment.AddFragments(fragments);
    }

    private static TNodeFragment CreateInternalFragment(string name)
    {
        return TryCreateFragment(name);
    }

    private static TNodeFragment TryCreateFragment(string name)
    {
        TNodeFragment? fragment;
        var fragmentType = typeof(TNodeFragment);
        var constructors = fragmentType.GetConstructors();

        var hasNameOnlyConstructor = constructors.Any(c =>
        {
            var parameters = c.GetParameters();
            if (parameters.Length != 1) return false;
            return parameters[0].ParameterType == typeof(string);
        });
        if (hasNameOnlyConstructor)
        {
            fragment = (TNodeFragment?) Activator.CreateInstance(typeof(TNodeFragment), name);
            return fragment!;
        }

        var hasNameArgsConstructor = constructors.Any(c =>
        {
            var parameters = c.GetParameters();
            if (parameters.Length != 2) return false;
            return parameters[0].ParameterType == typeof(string) &&
                   parameters[1].ParameterType.IsAssignableTo(typeof(IGraphQlQueryArgs));
        });
        if (hasNameArgsConstructor)
        {
            GraphQlConnectionArgs? args = null;
            fragment = (TNodeFragment?) Activator.CreateInstance(typeof(TNodeFragment), name, args);
            return fragment!;
        }

        throw new MissingMethodException($"{fragmentType.FullName} must have a constructor with `string` parameter");
    }
}