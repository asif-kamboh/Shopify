using ScientificBit.Shopify.Models;

namespace ScientificBit.Shopify.Requests;

public class DraftOrderInput
{
    public string Email { get; set; } = string.Empty;

    public string? Phone { get; set; } = string.Empty;

    public IList<DraftOrderLineItemInput> LineItems { get; set; } = new List<DraftOrderLineItemInput>();

    public MailingAddressInput? BillingAddress { get; set; }

    public MailingAddressInput? ShippingAddress { get; set; }

    public ShippingLineInput? ShippingLine { get; set; } 

    public string? PoNumber { get; set; }

    public string? SourceName { get; set; }

    public string? Note { get; set; }

    public string[]? Tags { get; set; }

    public string[]? DiscountCodes { get; set; }

    public MetafieldInput[]? Metafields { get; set; }

    public bool TaxExempt { get; set; } = true;

    public bool VisibleToCustomer { get; set; }

    public bool UseCustomerDefaultAddress { get; set; }

    public bool AcceptAutomaticDiscounts { get; set; }
    
    public bool AllowDiscountCodesInCheckout { get; set; }

    public DateTime? ReserveInventoryUntil { get; set; }

    public IList<ShopifyCustomAttribute>? CustomAttributes { get; set; }

    public DraftOrderAppliedDiscountInput? AppliedDiscount { get; set; }
}