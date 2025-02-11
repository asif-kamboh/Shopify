using Service.Shopify.Models.Base;

namespace Service.Shopify.Models;

public class TaxonomyCategoryAttribute : ShopifyBaseModel
{
    public string? Name {get; set;} // from TaxonomyChoiceListAttribute

    public GraphQlConnection<TaxonomyValue>? Values {get; set;} // from TaxonomyChoiceListAttribute
    
    public IList<ShopifyCustomAttribute>? Options {get; set;} // from TaxonomyMeasurementAttribute
}