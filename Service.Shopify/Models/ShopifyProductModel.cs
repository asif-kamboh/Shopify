using Newtonsoft.Json;
using Service.Shopify.Models.Base;

namespace Service.Shopify.Models;

public class ShopifyProductModel : ShopifyBaseModel
{
    public string? Title { get; set; }

    public string? TitleAr => GetArabicText(Translations, "title", Title);

    public string? Handle { get; set; }

    public string? Description { get; set; }

    public string? DescriptionHtml { get; set; }

    public string? ProductType { get; set; }

    public string? Vendor { get; set; }

    public List<string> Tags { get; set; } = new List<string>();

    public GraphQlConnection<ShopifyImage> Images { get; set; }

    public SeoModel? Seo { get; set; }

    public string Status { get; set; } = string.Empty;

    public bool TracksInventory { get; set; }

    public List<ShopifyTranslation> Translations { get; set; } = new();

    public List<Option>? Options { get; set; }

    public MetafieldModel? PaymentMethodsMetafield { get; set; }

    public MetafieldModel? ReviewsMetafield { get; set; }

    public MetafieldModel? RatingsMetafield { get; set; }

    public MetafieldModel? AddOnsMetafield { get; set; }

    public MetafieldModel? OrderLimitMetafield { get; set; }

    public MetafieldModel? OrderLimitDurationMetafield { get; set; }

    public MetafieldModel? PreOrderMetafield { get; set; }

    public MetafieldModel? BundleMetafield { get; set; }

    public List<string?>? ImageUrls()
    {
        return Images?.Nodes.Select(i => i.Url).ToList();
    }

    public int? OrderLimit()
    {
        return string.IsNullOrEmpty(OrderLimitMetafield?.Value)
            ? null
            : JsonConvert.DeserializeObject<int>(OrderLimitMetafield.Value);
    }

    public int? OrderLimitDuration()
    {
        return string.IsNullOrEmpty(OrderLimitDurationMetafield?.Value)
            ? null
            : JsonConvert.DeserializeObject<int>(OrderLimitDurationMetafield.Value);
    }

    public bool IsPreOrder()
    {
        return !string.IsNullOrEmpty(PreOrderMetafield?.Value) &&
               JsonConvert.DeserializeObject<bool>(PreOrderMetafield.Value);
    }

    public IList<string>? PaymentMethods()
    {
        return string.IsNullOrEmpty(PaymentMethodsMetafield?.Value)
            ? null
            : JsonConvert.DeserializeObject<List<string>>(PaymentMethodsMetafield.Value);
    }

    public string? Ratings()
    {
        return string.IsNullOrEmpty(RatingsMetafield?.Value) ? null : RatingsMetafield.Value;
    }

    public string? Reviews()
    {
        return string.IsNullOrEmpty(ReviewsMetafield?.Value) ? null : ReviewsMetafield.Value;
    }

    public string? Addons()
    {
        return string.IsNullOrEmpty(AddOnsMetafield?.Value) ? null : AddOnsMetafield.Value;
    }

    public string? Bundle()
    {
        return string.IsNullOrEmpty(BundleMetafield?.Value) ? null : BundleMetafield.Value;
    }

    private static string? GetArabicText(IList<ShopifyTranslation>? translations, string name, string? defaultVal)
    {
        return translations?.FirstOrDefault(t => name.Equals(t.Key, StringComparison.InvariantCultureIgnoreCase))
            ?.Value ?? defaultVal;
    }

    public class Option
    {
        public string? Name { get; set; }

        public List<string>? Values { get; set; }
    }

    public class SeoModel
    {
        public string? Title { get; set; }

        public string? Description { get; set; }
    }
}