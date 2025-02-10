using Service.Shopify.Requests.GraphQl;

namespace Service.Shopify.Builders.Fragments;

/// <summary>
/// Needs `read_users` access scope. Also, the app must be a finance embedded
/// app or installed on a Shopify Plus or Advanced store.
/// Contact Shopify Support to enable this scope for your app.
/// </summary>
public sealed class StaffMemberFragment : GraphQlFragment
{
    public StaffMemberFragment(string name, IGraphQlQueryArgs? args = null) : base(name, args)
    {
        AddFields(new []{"id", "email"});
    }
}