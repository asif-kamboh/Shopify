using ScientificBit.Shopify.Enums;
using ScientificBit.Shopify.Requests.GraphQl;

namespace ScientificBit.Shopify.Requests.Admin.Args;

public class ProductsCommonQueryParams
{
    public string? Default { get; set; }

    public GraphQlIdQueryStringParam? Id { get; set; }

    public string? Sku { get; set; }

    public string? Barcode { get; set; }

    public string? Title { get; set; }

    public string? Tag { get; set; }

    public string? TagNot { get; set; }

    public string? ProductType { get; set; }

    public bool? IsGiftCard { get; set; }

    public string? CategoryId { get; set; }

    public string? Vendor { get; set; }

    public GraphQlUpdatedAtQueryStringParam? UpdatedAt { get; set; }

    protected virtual IList<string> SerializeParams()
    {
        var tokens = new List<string>();

        if (!string.IsNullOrEmpty(Default)) tokens.Add($"default:{Default}");
        if (!string.IsNullOrEmpty(Title)) tokens.Add($"title:{Title}");
        if (!string.IsNullOrEmpty(Barcode)) tokens.Add($"barcode:{Barcode}");
        if (!string.IsNullOrEmpty(Sku)) tokens.Add($"sku:{Sku}");
        if (!string.IsNullOrEmpty(Vendor)) tokens.Add($"vendor:{Vendor}");
        if (!string.IsNullOrEmpty(CategoryId)) tokens.Add($"category_id:{CategoryId}");

        if (Id != null) tokens.Add(Id.ToString());
        if (UpdatedAt != null) tokens.Add(UpdatedAt.ToString());

        if (!string.IsNullOrEmpty(Tag)) tokens.Add($"tag:{Tag}");
        if (!string.IsNullOrEmpty(TagNot)) tokens.Add($"tag_not:{TagNot}");
        if (!string.IsNullOrEmpty(ProductType)) tokens.Add($"product_type:{ProductType}");

        if (IsGiftCard.HasValue) tokens.Add($"gift_card:{IsGiftCard.Value}");

        return tokens;
    }

    public override string ToString()
    {
        var tokens = SerializeParams();
        return tokens.Count > 0 ? string.Join(" AND ", tokens) : string.Empty;
    }

    protected static string BuildProductStatusQueryValue(int? status)
    {
        if (!status.HasValue) return string.Empty;

        var tokens = new List<string>();
        if (((int) ProductStatus.Active & status.Value) > 0)
        {
            tokens.Add(nameof(ProductStatus.Active).ToLower());
        }
        if (((int) ProductStatus.Draft & status) > 0)
        {
            tokens.Add(nameof(ProductStatus.Draft).ToLower());
        }
        if (((int) ProductStatus.Archived & status) > 0)
        {
            tokens.Add(nameof(ProductStatus.Archived).ToLower());
        }

        return tokens.Count > 0 ? string.Join(",", tokens) : "";
    }
}