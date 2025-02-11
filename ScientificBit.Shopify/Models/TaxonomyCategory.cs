using ScientificBit.Shopify.Models.Base;

namespace ScientificBit.Shopify.Models;

public class TaxonomyCategory : ShopifyBaseModel
{
    public string? ParentId { get; set; }

    public string? Name { get; set; }

    public string? FullName { get; set; }

    public IList<string>? AncestorIds { get; set; }

    public IList<string>? ChildrenIds { get; set; }

    public int? Level { get; set; }

    public bool? IsArchived { get; set; }

    public bool? IsRoot { get; set; }

    public bool? IsLeaf { get; set; }

    public GraphQlConnection<TaxonomyCategoryAttribute>? Attributes { get; set; }
}