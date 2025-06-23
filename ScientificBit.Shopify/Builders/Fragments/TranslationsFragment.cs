using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Builders.Fragments;

/// <summary>
/// Translations fragment is valid for specific types
/// </summary>
public sealed class TranslationsFragment : GraphQlFragment
{
    public TranslationsFragment(string name, TranslationQueryArgs args) : base(name, args)
    {
        AddFields(new[] {"key", "value", "locale"});
    }

    public TranslationsFragment(string locale) : this("translations", new TranslationQueryArgs { Locale = locale})
    {
    }
}