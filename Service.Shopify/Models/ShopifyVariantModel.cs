using Newtonsoft.Json;

namespace Service.Shopify.Models;

public class ShopifyVariantModel : ShopifyBaseModel
{
    public string? Title { get; set; } = string.Empty;
    
    public string? DisplayName { get; set; }

    public string Sku { get; set; } = string.Empty;

    public string Barcode { get; set; } = string.Empty;

    public double Price { get; set; }

    public bool Taxable { get; set; }

    public double? CompareAtPrice { get; set; }

    public ShopifyInventoryItem? InventoryItem { get; set; }

    public int InventoryQuantity { get; set; }

    public bool AvailableForSale { get; set; }

    public int SellableOnlineQuantity { get; set; }

    public List<SelectedOption> SelectedOptions { get; set; } = new ();

    public List<ShopifyTranslation>? Translations { get; set; }

    public ShopifyImage? Image { get; set; }

    public ShopifyProductModel? Product { get; set; }

    public string? ProductTitleAr => GetArabicTitle(Product?.Translations, Product?.Title);

    public MetafieldModel? PaymentMethodsMetafield { get; set; }

    public string? VariantTitleAr => GetArabicTitle(Translations, Title);

    public IList<string>? PaymentMethods()
    {
        return string.IsNullOrEmpty(PaymentMethodsMetafield?.Value)
            ? null
            : JsonConvert.DeserializeObject<List<string>>(PaymentMethodsMetafield.Value);
    }

    private static string? GetArabicTitle(IList<ShopifyTranslation>? translations, string? defaultVal)
    {
        return translations?.FirstOrDefault(t => "title".Equals(t.Key, StringComparison.InvariantCultureIgnoreCase))
            ?.Value ?? defaultVal;
    }

    public class SelectedOption
    {
        public string Name { get; set; } = string.Empty;

        public string Value { get; set; } = string.Empty;
    }
}