using ScientificBit.Shopify.Enums;

namespace ScientificBit.Shopify.Models;

public class ProductCreateInput
{
    public string? Title { get; set; }

    public string? Vendor { get; set; }

    /// <summary>
    /// Category ID of the product
    /// </summary>
    public string? Category { get; set; }

    public ClaimOwnershipInput? ClaimOwnership { get; set; }

    public string? DescriptionHtml { get; set; }

    public bool GiftCard { get; set; }

    public bool? RequiresSellingPlan { get; set; }

    public string? TemplateSuffix { get; set; }

    public string? GiftCardTemplateSuffix { get; set; }

    public string? Handle { get; set; }

    public string? ProductType { get; set; }

    public string Status { get; set; } = nameof(ProductStatus.Draft).ToUpper(); // ACTIVE, ARCHIVED, DRAFT

    public IList<string>? Tags { get; set; }

    public IList<string>? CollectionsToJoin { get; set; }
    /// <summary>
    /// CHILD or PARENT
    /// </summary>
    public string? CombinedListingRole { get; set; }

    public IList<MetafieldInput>? Metafields { get; set; }

    public IList<OptionCreateInput>? ProductOptions { get; set; }

    public SeoInput? Seo { get; set; }
}