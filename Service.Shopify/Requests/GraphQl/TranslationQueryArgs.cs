namespace Service.Shopify.Requests.GraphQl;

public class TranslationQueryArgs : GraphQlQueryArgs
{
    public string? Locale { get; set; }
}