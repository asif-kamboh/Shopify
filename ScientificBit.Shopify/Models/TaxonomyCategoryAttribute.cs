using ScientificBit.Shopify.Models.Base;

namespace ScientificBit.Shopify.Models;

public class TaxonomyCategoryAttribute : ShopifyBaseModel
{
    public string? Name {get; set;} // from TaxonomyChoiceListAttribute

    public GraphQlConnection<TaxonomyValue>? Values {get; set;} // from TaxonomyChoiceListAttribute
    
    public IList<ShopifyCustomAttribute>? Options {get; set;} // from TaxonomyMeasurementAttribute
}