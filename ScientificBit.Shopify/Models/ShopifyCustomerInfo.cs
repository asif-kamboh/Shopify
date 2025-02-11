namespace ScientificBit.Shopify.Models;

public class ShopifyCustomerInfo : MetafieldsSupportingModel
{
    public string Email { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string DisplayName { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public bool AcceptsMarketing { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? State { get; set; } = string.Empty;

    public ShopifyCustomerAddress? DefaultAddress { get; set; }

    public bool VerifiedEmail { get; set; }

    public IList<string>? Tags { get; set; } // tags
}