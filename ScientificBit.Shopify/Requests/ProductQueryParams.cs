using Refit;

namespace ScientificBit.Shopify.Requests;

public class ProductQueryParams : AdminApiQueryParams
{
    public ProductQueryParams()
    {
        Fields = "id,title,handle,status,vendor,variants,product_type";

        Limit = 250; // Max Limit
    }

    /// <summary>
    /// Comma-separated list of product handles
    /// </summary>
    [AliasAs("handle")]
    public string? Handle { get; set; }

    /// <summary>
    /// link to get prev or next page
    /// </summary>
    [AliasAs("page_info")]
    public string? PageInfo { get; set; }
    
    /// <summary>
    /// Products Ids separated by comma
    /// </summary>
    [AliasAs("ids")]
    public string? Ids { get; set; }
    
    /// <summary>
    /// Product Type 
    /// </summary>
    [AliasAs("product_type")]
    public string? ProductType { get; set; }
}