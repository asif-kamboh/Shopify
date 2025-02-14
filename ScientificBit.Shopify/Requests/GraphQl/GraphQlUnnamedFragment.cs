namespace ScientificBit.Shopify.Requests.GraphQl;

/// <summary>
/// A Fragment without a name, eg:
/// 
///     {
///         field1 filed2
///         fields3 {
///             innerField1 innerField2
///         }
///     }
/// 
/// </summary>
public class GraphQlUnnamedFragment : GraphQlFragment
{
    public const string TempName = "__unnamed";

    public GraphQlUnnamedFragment() : base(TempName)
    {
    }

    public override string ToString() => SerializedFragments();
}